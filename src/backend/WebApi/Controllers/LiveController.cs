using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class LiveController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get ()
        {
            return Ok();
        }
    }
}
