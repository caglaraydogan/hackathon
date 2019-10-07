using HackathonAPI.Helper;
using HackathonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HackathonAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            Student studentObj = new Student();
            studentObj.Name = "Caglar";
            studentObj.Department = "HR";
            studentObj.Email = "caglaraydogan@outlook.com";

            TableManager tableManager = new TableManager("person");
            // Insert  
            if (id <= 0)
            {
                studentObj.PartitionKey = "Student";
                studentObj.RowKey = Guid.NewGuid().ToString();
                
                tableManager.InsertEntity<Student>(studentObj, true);
            }
            // Update  
            else
            {
                studentObj.PartitionKey = "Student";
                studentObj.RowKey = Guid.NewGuid().ToString();
                
                tableManager.InsertEntity<Student>(studentObj, false);
            }

            List<Student> students = tableManager.RetrieveEntity<Student>();
            Student student = students.FirstOrDefault();

            return "";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
