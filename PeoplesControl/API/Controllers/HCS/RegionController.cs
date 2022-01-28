using Microsoft.AspNetCore.Http;
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

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : Controller
    {
        IRegionReadService _regionReadService;
        IRegionWriteService _regionWriteService;
        IAuthorizationService _authorizationService;
        IConfiguration _configuration;
        public RegionController(
            IRegionReadService regionReadService, 
            IAuthorizationService authorizationService, 
            IConfiguration configuration,
            IRegionWriteService regionWriteService
            )
        {
            _regionReadService = regionReadService;
            _regionWriteService = regionWriteService;
            _authorizationService = authorizationService;
            _configuration = configuration;
        }

        [HttpGet("Supported")]
        public RequestStatus<List<SupportedRegionDTO>> GetSupported([FromHeader] string Authorization)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Region:Supported"]);
            if (isAuthenticated){
                return _regionReadService.GetSupported();
            }
            else
            {
                return RequestStatus<List<SupportedRegionDTO>>.AuthFailed();
            }
        }

        [HttpGet("Unsupported")]
        public RequestStatus<List<UnsupportedRegionDTO>> GetUnsupported([FromHeader] string Authorization)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Region:Unsupported"]);
            if (isAuthenticated){
                return _regionReadService.GetUnsupported();
            }
            else
            {
                return RequestStatus<List<UnsupportedRegionDTO>>.AuthFailed();
            }
        }

        [HttpPut("{id}/MakeItSupported")]
        public bool MakeItSupported([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Region:Unsupported"]);
            if (isAuthenticated){
                return _regionWriteService.MakeItSupported(id, userId);
            }
            else
            {
                return false;
            }
        }

        [HttpPut("{id}/MakeItUnsupported")]
        public bool MakeItUnsupported([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Region:Unsupported"]);
            if (isAuthenticated){
                return _regionWriteService.MakeItUnsupported(id, userId);
            }
            else
            {
                return false;
            }
        }
    }
}
