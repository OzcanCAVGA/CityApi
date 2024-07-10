namespace CityApi.Core.Dtos.City
{
    public class GetCity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Istanbul";
        public int Population { get; set; } = 170000;
        public RgbCity Class { get; set; } = RgbCity.Marmara;
    }
}
