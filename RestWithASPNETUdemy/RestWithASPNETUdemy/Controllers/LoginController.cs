using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Authorization;
using RestWithASPNETUdemy.Models;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }
        
        [AllowAnonymous]
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public object Post([FromBody] User user)
        {
            if (user == null) return BadRequest();

            return new ObjectResult(_loginBusiness.FindByLogin(user));
        }
    }
}
