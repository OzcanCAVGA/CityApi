using CityApi.Core;
using Microsoft.EntityFrameworkCore;

namespace CityApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<CityEntity> CityEntities{ get; set; }
        public DbSet<UserEntity> UserEntities{ get; set; }
    }
}
