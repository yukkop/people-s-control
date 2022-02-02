using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.ReadServices;
using Logic.WriteServices;
using Logic.WebEntities;
using Logic.Helpers;
using Microsoft.Extensions.Configuration;
using DataBase.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        ICityWriteService _cityWriteService;
        ICityReadService _cityReadService;
        IAuthorizationService _authorizationService;
        IConfiguration _configuration;

        public CityController(ICityReadService cityReadService, ICityWriteService cityWriteService, IAuthorizationService authorizationService, IConfiguration configuration)
        {
            _cityReadService = cityReadService;
            _cityWriteService = cityWriteService;
            _authorizationService = authorizationService;
            _configuration = configuration;
        }

        [HttpGet]
        public RequestStatus<List<GetCityDTO>> Get([FromHeader] string Authorization)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:City:Get"]);
            if (isAuthenticated)  
            {  
                return _cityReadService.GetAll();
            }
            else
            {
                return RequestStatus<List<GetCityDTO>>.AuthFailed();
            }
        }
        
        [HttpGet("{id}")]
        public RequestStatus<GetCityDTO> Get([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:City:Get"]);
            if (isAuthenticated){
                return _cityReadService.Get(id);
            }
            else 
            {
                return RequestStatus<GetCityDTO>.AuthFailed();
            }
        }

        [HttpPost]
        public RequestStatus Post([FromHeader] string Authorization, [FromBody] CreateCityDTO createEntity)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:City:Add"]);
            if (isAuthenticated){
                return _cityWriteService.Add(createEntity);
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }

        [HttpPut("{id}")]
        public bool Put([FromHeader] string Authorization, [FromBody] UpdateCityDTO updateEntity)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:City:Update"]);
            if (isAuthenticated){
                return _cityWriteService.Update(updateEntity);
            }
            else
            {
                return false;
            }
        }

        [HttpDelete("{id}")]
        public RequestStatus Delete([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:City:Delete"]);
            if (isAuthenticated)
            {
                return _cityWriteService.Delete(id);
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }
    }
}
