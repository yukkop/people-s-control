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
    public class ProblemCategoryController : ControllerBase
    {
        IProblemCategoryWriteService _problemCategoryWriteService;
        IProblemCategoryReadService _problemCategoryReadService;
        IAuthorizationService _authorizationService;
        IConfiguration _configuration;

        public ProblemCategoryController(IProblemCategoryReadService problemCategoryReadService, IProblemCategoryWriteService problemCategoryWriteService, IAuthorizationService authorizationService, IConfiguration configuration)
        {
            _problemCategoryReadService = problemCategoryReadService;
            _problemCategoryWriteService = problemCategoryWriteService;
            _authorizationService = authorizationService;
            _configuration = configuration;
        }

        // GET: api/<ProblemCategoryController>
        [HttpGet]
        public ActionStatus<List<GetProblemCategoryDTO>> Get([FromHeader] string Authorization)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ProblemCategory:Get"]))
            {
                return _problemCategoryReadService.GetAll();
            }
            else
            {
                return null;
            }
        }

        // GET api/<ProblemCategoryController>/5
        [HttpGet("{id}")]
        public ActionStatus<GetProblemCategoryDTO> Get([FromHeader] string Authorization, long id)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ProblemCategory:Get"]))
            {
                return _problemCategoryReadService.Get(id);
            }
            else
            {
                return null;
            }
        }

        // POST api/<ProblemCategoryController>
        [HttpPost]
        public ActionStatus<GetProblemCategoryDTO> Post([FromHeader] string Authorization, [FromBody] CreateProblemCategoryDTO createEntity)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ProblemCategory:Add"]))
            {
                return _problemCategoryWriteService.Add(createEntity);
            }
            else
            {
                return null;
            }
        }

        // PUT api/<ProblemCategoryController>
        [HttpPut("{id}")]
        public bool Put([FromHeader] string Authorization, [FromBody] UpdateProblemCategoryDTO updateEntity)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ProblemCategory:Update"]))
            {
                return _problemCategoryWriteService.Update(updateEntity);
            }
            else
            {
                return false;
            }
        }

        // DELETE api/<ProblemCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete([FromHeader] string Authorization, long id, [FromBody] ActionMetaDTO data)
        {
            if (_authorizationService.Authorization(Authorization, _configuration["ActionsConfig:ProblemCategory:Delete"]))
            {
                _problemCategoryWriteService.Delete(id, data.UserId);
            }
        }
    }
}
