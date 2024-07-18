namespace CityApi.Core
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<CityEntity>? CityEntities { get; set; }

    }

}

