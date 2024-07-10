using AutoMapper;
using CityApi.Core;
using CityApi.Core.Dtos.City;


namespace CityApi.Services.CityService
{
    public class CityService : ICityService
    {
        private static List<CityEntity> cityEntities = new List<CityEntity>
        {
            new CityEntity(),
            new CityEntity{Id = 1, Name = "Trabzon"}
        };
        private readonly IMapper _mapper;

        public CityService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCity>>> AddCity(AddCity newCity)
        {
            var serviceResponse = new ServiceResponse<List<GetCity>>();
            CityEntity city = _mapper.Map<CityEntity>(newCity);
            city.Id = cityEntities.Max(x => x.Id) + 1;
            cityEntities.Add(city);
            serviceResponse.Data = cityEntities.Select(x => _mapper.Map<GetCity>(x)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetCity>>> GetAllCity()
        {

            var serviceResponse = new ServiceResponse<List<GetCity>> { Data = cityEntities.Select(x => _mapper.Map<GetCity>(x)).ToList() };
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCity>> GetAllCityById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCity>();
            var city = cityEntities.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCity>(city);
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetCity>> UpdateCity(UpdateCity updatedCity)
        {
            ServiceResponse<GetCity> serviceresponse = new ServiceResponse<GetCity>();
            try
            {
                CityEntity city = cityEntities.FirstOrDefault(c => c.Id == updatedCity.Id);
                city.Name = updatedCity.Name;
                city.Population = updatedCity.Populasyon;
                city.Class = updatedCity.Class;

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
                CityEntity city = cityEntities.First(c => c.Id == id);
                cityEntities.Remove(city);
                serviceresponse.Data = cityEntities.Select(x => _mapper.Map<GetCity>(x)).ToList();
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
