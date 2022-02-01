using DataBase.Models;
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
    public class ReportController : ControllerBase
    {
        IReportWriteService _reportWriteService;
        IReportReadService _reportReadService;
        IAuthorizationService _authorizationService;
        IReportViewWriteService _reportViewWriteService;
        IReportByProblemCategoryWriteService _reportByProblemCategoryWriteService;
        IConfiguration _configuration;

        public ReportController(IReportReadService reportReadService, IReportWriteService reportWriteService, 
                                IReportViewWriteService reportViewWriteService, IReportByProblemCategoryWriteService reportByProblemCategoryWriteService, 
                                IAuthorizationService authorizationService, IConfiguration configuration)
        {
            _reportReadService = reportReadService;
            _reportWriteService = reportWriteService;
            _reportViewWriteService = reportViewWriteService;
            _reportByProblemCategoryWriteService = reportByProblemCategoryWriteService;
            _authorizationService = authorizationService;
            _configuration = configuration;
        }

        [HttpGet("page")] //Достать страницу с учетом сортировки (ShortReport)
        public RequestStatus<List<ShortShowReportDTO>> GetPage([FromHeader] string Authorization, [FromBody] RequestReportsPageDTO pageSettings)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Report:Get"]);
            if (isAuthenticated)
            {
                return _reportReadService.GetPage(pageSettings);
            }
            else
            {
                return RequestStatus<List<ShortShowReportDTO>>.AuthFailed();
            }
        }

        [HttpGet("page/nearby")] //Достать страницу с учетом сортировки (ShortReport)
        public RequestStatus<List<ShortShowReportDTO>> GetPageNearbyReports([FromHeader] string Authorization, [FromBody] RequerstNearbyReportsPageDTO pageSettings)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Report:Get"]);
            if (isAuthenticated)
            {
                return _reportReadService.GetPageNearbyReports(pageSettings);
            }
            else
            {
                return RequestStatus<List<ShortShowReportDTO>>.AuthFailed();
            }
        }

        [HttpGet("{id}")] // Страница репорта
        public RequestStatus<GetReportDTO> Get([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Report:Get"]);
            if (isAuthenticated){
                return _reportReadService.Get(id);
            }
            else
            {
                return RequestStatus<GetReportDTO>.AuthFailed();
            }
        }

        [HttpPost]
        public RequestStatus Post([FromHeader] string Authorization, [FromBody] CreateReportDTO createEntity)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Report:Add"]);
            if (isAuthenticated){
                return _reportWriteService.Create(createEntity, userId);
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }

        [HttpPost("{id}/view")]
        public RequestStatus PostReportView([FromHeader] string Authorization, long id)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ReportView:Add"]);
            if (isAuthenticated){
                return _reportViewWriteService.Add(id, userId);
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }
        // POST api/<ReportController>
        [HttpPost("{id}/put/Category/{categoryId}")]
        public RequestStatus PostProblemCategory([FromHeader] string Authorization, long id, long categoryId)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ReportByProblemCategory:Add"]);
           if (isAuthenticated) {
                return _reportByProblemCategoryWriteService.Add(id, categoryId);
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }
        [HttpPost("{id}/Delete/Category/{categoryId}")]
        public RequestStatus DeleteProblemCategory([FromHeader] string Authorization, long id, long categoryId)
        {
            var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ReportByProblemCategory:Delete"]);
            if (isAuthenticated){
                return _reportByProblemCategoryWriteService.Delete(id, categoryId);
            }
            else
            {
                return RequestStatus.AuthFailed();
            }
        }

        //[HttpPut("{id}")]
        //public bool Put([FromHeader] string Authorization, [FromBody] UpdateReportDTO updateEntity)
        //{
        //    var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Report:Update"]);
        //    if (isAuthenticated){
        //        return _reportWriteService.Update(updateEntity);
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //[HttpDelete("{id}")]
        //public void Delete([FromHeader] string Authorization, long id)
        //{
        //    var (isAuthenticated, userId) = _authorizationService.Authorization(Authorization, _configuration["ActionsConfig:Report:Delete"]);
        //    if (isAuthenticated){
        //        _reportWriteService.Delete(id);
        //    }
        //}
    }
}
