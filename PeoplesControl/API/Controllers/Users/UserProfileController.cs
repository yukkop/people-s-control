using Logic.Helpers;
using Logic.ReadServices;
using Logic.WebEntities;
using Logic.WriteServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        IUserProfileWriteService _userProfileWriteService;
        IUserProfileReadService _userProfileReadService;
        IAuthorizationService _authorizationService;
        IConfiguration _configuration;

        public UserProfileController(IUserProfileReadService userProfileReadService, IUserProfileWriteService userProfileWriteService, IAuthorizationService authorizationService, IConfiguration configuration)
        {
            _userProfileReadService = userProfileReadService;
            _userProfileWriteService = userProfileWriteService;
            _authorizationService = authorizationService;
            _configuration = configuration;
        }
        
        /*[HttpGet("{id}")]
        public string Get()
        {
            return "asd";
        }

        [HttpGet("алала/{id1}")]
        public string Get1()
        {
            return "asdaaaaa";
        }

        [HttpGet("{id}/{id1}/{i2d}")]
        public string Get2()
        {
            return "assssssssssd";
        }
        
        // GET: api/<UserProfileController>
        [HttpGet]
        public ActionStatus<List<GetUserProfileDTO>> Get([FromHeader] string Authorization)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:UserProfile:Get"]))
            {
                return _userProfileReadService.GetAll();
            }
            else
            {
                return null;
            }
        }
        */

        [HttpGet("Authorization")]
        public RequestStatus Authorization([FromHeader] string Authorization)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:UserProfile:Authorization"]);
            if (isAuthenticated){
                return new RequestStatus(RequestStatus.Statuses.Ok, "Аккаунт подтвержден");
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }
        
        [HttpPost("registration/Email")]
        public RequestStatus RegistrationByEmail([FromHeader] string Authorization, [FromBody] RegistrationByEmailDTO registration)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:UserProfile:Registration"]);
            if (isAuthenticated)
            {
                return _userProfileWriteService.RegistrationByEmail(registration);
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }
        [HttpPut("registration/Email/{confirmationCode}")]
        public RequestStatus ConfirmEmail([FromHeader] string Authorization, int confirmationCode)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:UserProfile:Confirmation"]);
            if (isAuthenticated)
            {
                return _userProfileWriteService.ConfirmEmail(userId, confirmationCode);
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }

        [HttpPut("role/remove/driver")]
        public RequestStatus RemoveDriverRole([FromHeader] string Authorization)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:UserProfile:Registration"]);
            if (isAuthenticated)
            {
                return RequestStatus.Ok();
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }

        [HttpPut("role/add/driver")]
        public RequestStatus AddDriverRole([FromHeader] string Authorization)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:UserProfile:Registration"]);
            if (isAuthenticated)
            {
                return RequestStatus.Ok();
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }

        [HttpPut("registration/Email/resend")]
        public RequestStatus ResendConfirmationCodeEmail([FromHeader] string Authorization)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:UserProfile:Confirmation"]);
            if (isAuthenticated)
            {
                return _userProfileWriteService.ResendConfirmationCodeEmail(userId);
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }
    }
}
