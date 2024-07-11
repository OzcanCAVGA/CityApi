using CityApi.Core;
using CityApi.Core.Dtos.City;
using CityApi.Services.CityService;
using Microsoft.AspNetCore.Mvc;

namespace CityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCity>>>> Get()
        {
            return Ok(await _cityService.GetAllCity());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCity>>> GetSingle(int id)

        {

            return Ok(await _cityService.GetAllCityById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCity>>>> AddCity(AddCity newcity)
        {

            return Ok(await _cityService.AddCity(newcity));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCity>>> UpdateCity(UpdateCity updatedCity)
        {
            var response = await _cityService.UpdateCity(updatedCity);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCity>>>> DeleteCity(int id)
        {
            var response = await _cityService.DeleteCity(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    
    }
}
