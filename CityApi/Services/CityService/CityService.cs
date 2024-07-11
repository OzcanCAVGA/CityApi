using AutoMapper;
using CityApi.Core;
using CityApi.Core.Dtos.City;
using CityApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CityApi.Services.CityService
{
    public class CityService : ICityService
    {
        
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CityService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCity>>> AddCity(AddCity newCity)
        {
            var serviceResponse = new ServiceResponse<List<GetCity>>();
            CityEntity city = _mapper.Map<CityEntity>(newCity);
            _context.CityEntities.Add(city);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.CityEntities.Select(x => _mapper.Map<GetCity>(x)).ToListAsync();
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetCity>>> GetAllCity()
        {

            var response = new ServiceResponse<List<GetCity>>();
            var dbCityEntities = await _context.CityEntities.ToListAsync();
            response.Data = dbCityEntities.Select(x => _mapper.Map<GetCity>(x)).ToList();
            return response;
        }
        public async Task<ServiceResponse<GetCity>> GetAllCityById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCity>();
            var dbcity = await _context.CityEntities.FirstOrDefaultAsync(x => x.Id == id);
            serviceResponse.Data = _mapper.Map<GetCity>(dbcity);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCity>> UpdateCity(UpdateCity updatedCity)
        {
            ServiceResponse<GetCity> serviceresponse = new ServiceResponse<GetCity>();
            try
            {
                var city = await _context.CityEntities.FirstOrDefaultAsync(c => c.Id == updatedCity.Id);
                city.Name = updatedCity.Name;
                city.Population = updatedCity.Populasyon;
                city.Class = updatedCity.Class;

                await _context.SaveChangesAsync();

                serviceresponse.Data = _mapper.Map<GetCity>(city);
            }
            catch (Exception ex)
            {
                serviceresponse.Success = false;
                serviceresponse.Message = ex.Message;
            }

            return serviceresponse;
        }


        public async Task<ServiceResponse<List<GetCity>>> DeleteCity(int id)
        {

            ServiceResponse<List<GetCity>> serviceresponse = new ServiceResponse<List<GetCity>>();
            try
            {
                CityEntity city = await _context.CityEntities.FirstAsync(c => c.Id == id);
                _context.CityEntities.Remove(city);
                await _context.SaveChangesAsync();
                serviceresponse.Data = _context.CityEntities.Select(x => _mapper.Map<GetCity>(x)).ToList();
            }
            catch (Exception ex)
            {
                serviceresponse.Success = false;
                serviceresponse.Message = ex.Message;
            }

            return serviceresponse;

        }
    }
}
