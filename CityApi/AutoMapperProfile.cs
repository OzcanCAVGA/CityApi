using AutoMapper;
using CityApi.Core;
using CityApi.Core.Dtos.City;

namespace CityApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CityEntity, GetCity>();
            CreateMap<AddCity, CityEntity>();
           
        }
    }
}
