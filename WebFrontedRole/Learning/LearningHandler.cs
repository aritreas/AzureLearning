using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace WebFrontedRole.Learning
{
    public class LearningHandler
    {
        // inherit from cloudtable class
        // use ICloudTable (because of unittesting)
        private readonly CloudTable _tableCourses;

        private readonly CloudStorageAccount _storageAccount =
            CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

        private readonly GetResponses _responses = new GetResponses();

        // inject cloudtable to the constructor
        public LearningHandler()
        {
            // creates the table client
            CloudTableClient tableLearning = _storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "courses" table.
            _tableCourses = tableLearning.GetTableReference("courses");
            _tableCourses.CreateIfNotExists();
        }

        public async Task<HttpResponseMessage> UpdateLearningCourses(string username, HttpRequestMessage request)
        {
            if (username == null) return _responses.CreateHttpBadRequest();

            var content = await request.Content.ReadAsStringAsync();
            if (content == "") return _responses.CreateHttpBadRequest();
            
            var userCourseDict = JsonConvert.DeserializeObject<Dictionary<string, int>>(content);

            foreach (KeyValuePair<string, int> entry in userCourseDict)
            {
                UpdateCourseEntity(username, entry);
            }
            return _responses.CreateHttpOk();
        }

        public HttpResponseMessage GetPercentCourse(string username, string course)
        {
            if (username == null) return _responses.CreateHttpBadRequest();

            var userCourse = GetCourse(username, course);
            return userCourse != null ? _responses.CreateHttpOkCourses(userCourse) : _responses.CreateHttpBadRequest();
        }

        public HttpResponseMessage GetPercentCourses(string username)
        {
            if (username == null) return _responses.CreateHttpBadRequest();

            var userCoursesList = GetCourses(username);
            return userCoursesList != null
                ? _responses.CreateHttpOkCourses(userCoursesList)
                : _responses.CreateHttpBadRequest();
        }

        private UserCourses GetCourse(string username, string course)
        {
            TableQuery<CoursesEntity> query = new TableQuery<CoursesEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, username));
            // look how fetchRow works in shared code

            foreach (CoursesEntity entity in _tableCourses.ExecuteQuery(query))
            {
                if (entity.RowKey != course) continue;

                var userCourseDict = new Dictionary<string, int>();
                userCourseDict[entity.RowKey] = entity.Percent;
                var courses = JsonConvert.SerializeObject(userCourseDict);
                return new UserCourses(username, courses);
            }
            return null;
        }

        private UserCourses GetCourses(string username)
        {
            TableQuery<CoursesEntity> query = new TableQuery<CoursesEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, username));

            var userCourseDict = new Dictionary<string, int>();
            foreach (CoursesEntity entity in _tableCourses.ExecuteQuery(query))
            {
                userCourseDict[entity.RowKey] = entity.Percent;
            }
            if (userCourseDict.Count <= 0) return null;

            var courses = JsonConvert.SerializeObject(userCourseDict);
            return new UserCourses(username, courses);
        }

        private void UpdateCourseEntity( string username, KeyValuePair<string, int> entry)
        {
            CoursesEntity courses = new CoursesEntity(username, entry.Key, entry.Value);
            TableOperation insertOperation = TableOperation.InsertOrReplace(courses);
            _tableCourses.Execute(insertOperation);
        }
    }
}