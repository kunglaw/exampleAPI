using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace exampleAPI.Controllers
{
    public class ProductController : ApiController
    {
        // GET: api/Product
       
        public string Get()
        {
            //var obj = new { name = "value1", age = "value2" };
            return "Hello World"; 
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "hello "+id;
        }

        // POST: api/Product
        public string Post([FromBody]string value)
        {
            //Console.WriteLine(value);
            return value;
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
