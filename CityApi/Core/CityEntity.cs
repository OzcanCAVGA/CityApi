namespace CityApi.Core
{
    public class CityEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Istanbul";
        public int Population { get; set; } = 170000;
        public RgbCity Class { get; set; } = RgbCity.Marmara;
        public UserEntity? User { get; set; }
    }
}
