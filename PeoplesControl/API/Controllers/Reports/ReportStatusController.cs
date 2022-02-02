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
    public class ReportStatusController : ControllerBase
    {
        IReportStatusWriteService _reportStatusWriteService;
        IReportStatusReadService _reportStatusReadService;
        IAuthorizationService _authorizationService;
        IConfiguration _configuration;

        public ReportStatusController(IReportStatusReadService reportStatusReadService, IReportStatusWriteService reportStatusWriteService, IAuthorizationService authorizationService, IConfiguration configuration)
        {
            _reportStatusReadService = reportStatusReadService;
            _reportStatusWriteService = reportStatusWriteService;
            _authorizationService = authorizationService;
            _configuration = configuration;
        }

        // GET: api/<ReportStatusController>
        [HttpGet]
        public RequestStatus<List<GetReportStatusDTO>> Get([FromHeader] string Authorization)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ReportStatus:Get"]);
           if (isAuthenticated) {
                return _reportStatusReadService.GetAll();
            }
            else
            {
                return null;
            }
        }

        // GET api/<ReportStatusController>/5
        [HttpGet("{id}")]
        public RequestStatus<GetReportStatusDTO> Get([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ReportStatus:Get"]);
            if (isAuthenticated){
                return _reportStatusReadService.Get(id);
            }
            else
            {
                return null;
            }
        }

        // POST api/<ReportStatusController>
        [HttpPost]
        public RequestStatus<GetReportStatusDTO> Post([FromHeader] string Authorization, [FromBody] CreateReportStatusDTO createEntity)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ReportStatus:Add"]);
            if (isAuthenticated){                                                                                                                
                return _reportStatusWriteService.Add(createEntity);
            }
            else
            {
                return null;
            }
        }

        // PUT api/<ReportStatusController>
        [HttpPut("{id}")]
        public bool Put([FromHeader] string Authorization, [FromBody] UpdateReportStatusDTO updateEntity)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ReportStatus:Update"]);
            if (isAuthenticated){
                return _reportStatusWriteService.Update(updateEntity);
            }
            else
            {
                return false;
            }
        }

        // DELETE api/<ReportStatusController>/5
        [HttpDelete("{id}")]
        public void Delete([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ReportStatus:Delete"]);
            if (isAuthenticated){
                _reportStatusWriteService.Delete(id);
            }
        }
    }
}
