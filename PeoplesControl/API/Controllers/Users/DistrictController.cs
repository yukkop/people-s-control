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
    public class DistrictController : ControllerBase
    {
        IDistrictWriteService _districtWriteService;
        IDistrictReadService _districtReadService;
        IAuthorizationService _authorizationService;
        IConfiguration _configuration;

        public DistrictController(IDistrictReadService districtReadService, IDistrictWriteService districtWriteService, IAuthorizationService authorizationService, IConfiguration configuration)
        {
            _districtReadService = districtReadService;
            _districtWriteService = districtWriteService;
            _authorizationService = authorizationService;
            _configuration = configuration;
        }

        [HttpGet]
        public RequestStatus<List<GetDistrictDTO>> Get([FromHeader] string Authorization)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:District:Get"]);
            if (isAuthenticated){
                return _districtReadService.GetAll();
            }
            else
            {
                return RequestStatus<List<GetDistrictDTO>>.AuthFailed();
            }
        }

        [HttpGet("{id}")]
        public RequestStatus<GetDistrictDTO> Get([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:District:Get"]);
            if (isAuthenticated)
            {
                return _districtReadService.Get(id);
            }
            else
            {
                return RequestStatus<GetDistrictDTO>.AuthFailed();
            }
        }

        [HttpGet("ByCity/{name}")]
        public RequestStatus< List<GetDistrictDTO> >GetByCityName([FromHeader] string Authorization, string name)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:District:Get"]);
            if (isAuthenticated)
            {
                return _districtReadService.GetByCityName(name);
            }
            else
            {
                return RequestStatus<List<GetDistrictDTO>>.AuthFailed();
            }
        }

        [HttpPost]
        public GetDistrictDTO Post([FromHeader] string Authorization, [FromBody] CreateDistrictDTO createEntity)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:District:Add"]);
            if (isAuthenticated){
                return _districtWriteService.Add(createEntity);
            }
            else
            {
                return null;
            }
        }

        [HttpPut("{id}")]
        public bool Put([FromHeader] string Authorization, [FromBody] UpdateDistrictDTO updateEntity)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:District:Update"]);
            if (isAuthenticated){
                return _districtWriteService.Update(updateEntity);
            }
            else
            {
                return false;
            }
        }

        [HttpDelete("{id}")]
        public bool Delete([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:District:Delete"]);
            if (isAuthenticated){
                _districtWriteService.Delete(id);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
