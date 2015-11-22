using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace WebFrontedRole.Learning
{
    // TODO make it internal
    public class CoursesEntity : TableEntity
    {
        public int Percent { get; set; }

        public CoursesEntity(string username, string course, int percent)
        {
            if (username == null) throw new ArgumentNullException("username");
            if (course == null) throw new ArgumentNullException("course");

            PartitionKey = username;
            RowKey = course;
            Percent = percent;
        }

        public CoursesEntity()
        {
            throw new NotImplementedException();
        }
    }
}