using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotNetCore.Models;

namespace dotNetCore.Controllers
{

    [Route("testAPI/[controller]")]
    public class AccountController : Controller
    {
        //Our repository:
        private static Dictionary<int, Person> accounts = new Dictionary<int, Person>();

        // GET testAPI/account
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return accounts.Values;
        }

        // GET testAPI/account/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Person dummy ;
            if (accounts.TryGetValue(id, out dummy))
                return new ObjectResult(dummy);
            else 
                //return 404
                return NotFound();
        }

        // POST testAPI/account
        [HttpPost]
        public void Post([FromBody]Person value)
        {
            value.id = accounts.Count;
            accounts[value.id] = value;

        }

        // PUT testAPI/account/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Person value)
        {
            accounts[id] = value;
        }

        // DELETE testAPI/accout/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            accounts.Remove(id);
        }

        //ADD bookmarks:

    }
}
