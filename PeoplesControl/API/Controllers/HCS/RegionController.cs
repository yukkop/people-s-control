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
        public List<SupportedRegionDTO> GetSupported([FromHeader] string Authorization)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Region:Supported"]))
            {
                return _regionReadService.GetSupported();
            }
            else
            {
                return null;
            }
        }

        [HttpGet("Unsupported")]
        public List<UnsupportedRegionDTO> GetUnsupported([FromHeader] string Authorization)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Region:Unsupported"]))
            {
                return _regionReadService.GetUnsupported();
            }
            else
            {
                return null;
            }
        }

        [HttpPut("{id}/MakeItSupported")]
        public bool MakeItSupported([FromHeader] string Authorization, long id)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Region:Unsupported"]))
            {
                return _regionWriteService.MakeItSupported(id);
            }
            else
            {
                return false;
            }
        }

        [HttpPut("{id}/MakeItUnsupported")]
        public bool MakeItUnsupported([FromHeader] string Authorization, long id)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Region:Unsupported"]))
            {
                return _regionWriteService.MakeItUnsupported(id);
            }
            else
            {
                return false;
            }
        }
    }
}
