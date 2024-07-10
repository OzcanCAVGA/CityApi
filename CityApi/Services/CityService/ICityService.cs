using CityApi.Core;
using CityApi.Core.Dtos.City;

namespace CityApi.Services.CityService
{
    public interface ICityService
    {
        Task<ServiceResponse<List<GetCity>>> GetAllCity();
        Task<ServiceResponse<GetCity>> GetAllCityById(int id);
        Task<ServiceResponse<List<GetCity>>> AddCity(AddCity newCity);
        Task<ServiceResponse<GetCity>> UpdateCity(UpdateCity updatedCity);
        Task<ServiceResponse<List<GetCity>>> DeleteCity(int id);
    }
}
