using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.ReadServices;
using Logic.WriteServices;
using Logic.WebEntities;
using Logic.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        ICityWriteService _cityWriteService;
        ICityReadService _cityReadService;

        public CityController(ICityReadService cityReadService, ICityWriteService cityWriteService)
        {
            _cityReadService = cityReadService;
            _cityWriteService = cityWriteService;
        }

        // GET: api/<CityController>
        [HttpGet]
        public ActionStatus<List<GetCityDTO>> Get()
        {
            return _cityReadService.GetAll();
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public ActionStatus<GetCityDTO> Get(long id)
        {
            return _cityReadService.Get(id);
        }

        // POST api/<CityController>
        [HttpPost]
        public ActionStatus<GetCityDTO> Post([FromBody] CreateCityDTO createEntity)
        {
            return _cityWriteService.Add(createEntity);
        }

        // PUT api/<CityController>
        [HttpPut("{id}")]
        public bool Put([FromBody] UpdateCityDTO updateEntity)
        {
            return _cityWriteService.Update(updateEntity);
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _cityWriteService.Delete(id);
        }
    }
}
