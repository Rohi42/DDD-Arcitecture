using JWTHandler;
using JWTHandler.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private JWTTokenHandler _jwtTokenHandler;
        public AuthenticationController(JWTTokenHandler jWTTokenHandler)
        {
            _jwtTokenHandler = jWTTokenHandler;
        }
        [HttpGet]
        [Route("/Authenticate")]
        public ActionResult<AuthenticationResponse> GetAuthentication(AuthenticationRequest request)
        {
            var authenticationresponse=_jwtTokenHandler.GenerateJwt(request);
            if(authenticationresponse == null) { return Unauthorized(); }
            return Ok(authenticationresponse);
        }
    }
}
