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
    [Route("api/[controller]")]
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
        public bool Authorization([FromHeader] string Authorization)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:UserProfile:Authorization"]);
            if (isAuthenticated){
                return true;
            }
            else
            {
                return false;
            }
        }
        
        [HttpPost]
        public bool Registration([FromHeader] string Authorization, [FromBody] RegistrationDTO registration)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:UserProfile:Registration"]);
            if (isAuthenticated)
            {
                _userProfileWriteService.Registration(registration);
                return true;
            }
            else
            {
                return false;
            }
        }
/*
        // PUT api/<UserProfileController>
        [HttpPut("{id}")]
        public bool Put([FromHeader] string Authorization, [FromBody] UpdateUserProfileDTO updateEntity)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:UserProfile:Update"]))
            {
                return _userProfileWriteService.Update(updateEntity);
            }
            else
            {
                return false;
            }
        }

        // DELETE api/<UserProfileController>/5
        [HttpDelete("{id}")]
        public void Delete([FromHeader] string Authorization, long id)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:UserProfile:Delete"]))
            {
                _userProfileWriteService.Delete(id);
            }
        }*/
    }
}
