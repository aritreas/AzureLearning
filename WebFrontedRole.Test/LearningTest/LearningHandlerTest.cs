using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage;
using WebFrontedRole.Learning;
using Moq;

namespace WebFrontedRole.Test.LearningTest
{
    [TestClass]
    public class LearningHandlerTest
    {
        private Mock<CloudStorageAccount> cloudStorageAccount;
        private MockRepository mockRepository;

        [TestInitialize]
        public void setup()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            cloudStorageAccount = mockRepository.Create<CloudStorageAccount>();
        }

        [TestMethod
      
        public void GetPercentCourse_ShouldReturnBadRequest_IfNullUsername()
        {   
            var learningHandler = new LearningHandler();
            var response = learningHandler.GetPercentCourse(null, "course");
            Assert.AreEqual(response., HttpStatusCode.BadRequest;

        }
        public HttpResponseMessage GetPercentCourse(string username, string course)
        {
            if (username == null) return _responses.CreateHttpBadRequest();

            var userCourse = GetCourse(username, course);
            return userCourse != null ? _responses.CreateHttpOkCourses(userCourse) : _responses.CreateHttpBadRequest();
        }
        [TestMethod]
        public void UpdateLearningCourses_ShouldReturnBadResponse_GivenNullUsername()
        {
            var learningHandler = new LearningHandler();
            var request = new HttpRequestMessage();
            Task<HttpResponseMessage> response = learningHandler.UpdateLearningCourses(null, request);

            Assert.AreEqual(response, HttpStatusCode.BadRequest);
        }
//        public async Task<HttpResponseMessage> UpdateLearningCourses(string username, HttpRequestMessage request)
//        {
//            if (username == null) return _responses.CreateHttpBadRequest();
//
//            var content = await request.Content.ReadAsStringAsync();
//            if (content == "") return _responses.CreateHttpBadRequest();
//
//            var userCourseDict = JsonConvert.DeserializeObject<Dictionary<string, int>>(content);
//
//            foreach (KeyValuePair<string, int> entry in userCourseDict)
//            {
//                UpdateCourseEntity(username, entry);
//            }
//            return _responses.CreateHttpOk();
//        }
    
    }


}
