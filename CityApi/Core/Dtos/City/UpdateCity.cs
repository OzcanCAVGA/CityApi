namespace CityApi.Core.Dtos.City
{
    public class UpdateCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Populasyon { get; set; } = 170000;
        public RgbCity Class { get; set; } = RgbCity.Marmara;
    }
}
