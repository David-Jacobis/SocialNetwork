using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static OpenAI.ObjectModels.SharedModels.IOpenAiModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("{culture:culture}/api/[controller]")]
    public class ApiBaseController : ControllerBase
    {
        //public readonly IUser _user;
        //IUser user
        public ApiBaseController()
        {
            //_user = user;
            //if (_user.IsAuthenticated())
            //{
            //    Username = _user.GetUserName();
            //    IsAuthenticated = true;
            //}
        }

        protected string Username { get; set; }
        protected bool IsAuthenticated { get; set; }

        protected ActionResult Success (object result = null)
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        protected ActionResult Error(object result = null)
        {
            return BadRequest(new
            {
                success = false,
                data = result
            });
        }
    }
}
