using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChoreManager.Models;
using ChoreManager.DataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChoreManager.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IRepository<User> _users;

        public UserController(IRepository<User> users)
        {
            _users = users;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            return StatusCode(200, _users.GetAll());
        }

        // GET api/<controller>/name
        [HttpGet("{name}")]
        public ActionResult Get(string name)
        {
            return StatusCode(200, _users.Get(name));
        }

        // POST api/<controller>
        [HttpPost]
        public StatusCodeResult Post([FromBody]User value)
        {
            _users.Add(value);
            return StatusCode(201);
        }

        // PUT api/<controller>/name
        [HttpPut("{name}")]
        public StatusCodeResult Put(string name, [FromBody]User value)
        {
            _users.Update(name,value);
            return StatusCode(204);
        }

        // DELETE api/<controller>/name
        [HttpDelete("{name}")]
        public StatusCodeResult Delete(string name)
        {
            _users.Delete(name);
            return StatusCode(204);
        }
    }
}
