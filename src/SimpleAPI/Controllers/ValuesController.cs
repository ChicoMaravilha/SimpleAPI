using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;



namespace SimpleAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("api/{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Chico The";
        }
    }
}
