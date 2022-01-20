using Logic.Helpers;
using Logic.ReadServices;
using Logic.WebEntities;
using Logic.WriteServices;
using Microsoft.AspNetCore.Mvc;
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

        public DistrictController(IDistrictReadService districtReadService, IDistrictWriteService districtWriteService)
        {
            _districtReadService = districtReadService;
            _districtWriteService = districtWriteService;
        }

        // GET: api/<DistrictController>
        [HttpGet]
        public ActionStatus<List<GetDistrictDTO>> Get()
        {
            return _districtReadService.GetAll();
        }

        // GET api/<DistrictController>/5
        [HttpGet("{id}")]
        public ActionStatus<GetDistrictDTO> Get(long id)
        {
            return _districtReadService.Get(id);
        }

        // POST api/<DistrictController>
        [HttpPost]
        public ActionStatus<GetDistrictDTO> Post([FromBody] CreateDistrictDTO createEntity)
        {
            return _districtWriteService.Add(createEntity);
        }

        // PUT api/<DistrictController>
        [HttpPut("{id}")]
        public bool Put([FromBody] UpdateDistrictDTO updateEntity)
        {
            return _districtWriteService.Update(updateEntity);
        }

        // DELETE api/<DistrictController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _districtWriteService.Delete(id);
        }
    }
}
