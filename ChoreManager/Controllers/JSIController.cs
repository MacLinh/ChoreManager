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
    public class JSIController : Controller
    {
	private static readonly string[] JSITypes = { "Sms" };

        private readonly IRepository<JSISms> _sms;

        public JSIController(IRepository<JSISms> sms)
        {
            _sms = sms;
        }
	
	// JSI DELIVERABLE 2

        // GET: api/jsi/types
        [HttpGet("types")]
        public ActionResult GetTypes()
        {
            return StatusCode(200, JSITypes);
        }

        // GET api/jsi/sms
        [HttpGet("sms")]
        public ActionResult GetSms()
        {
            return StatusCode(200, _sms.GetAll());
        }

        // POST api/jsi/timefilter
        [HttpPost("timefilter")]
        public StatusCodeResult Post([FromBody] TimeFilter filter)
        {
	    // match the types to the correct repository (such as sms)
	    // return error if not supported

            // run through repository to check if date time is valid

	    // var sms = _sms.GetAll()) 

	    // do logic

            throw new NotImplementedException();   
        }

        // PUT api/<controller>/name
        [HttpPut("{name}")]
        public StatusCodeResult Put(string name, [FromBody] JSISms value)
        {
            throw new NotImplementedException();        }

        // DELETE api/<controller>/name
        [HttpDelete("{name}")]
        public StatusCodeResult Delete(string name)
        {
            throw new NotImplementedException();
        }
    }
}
