using Microsoft.EntityFrameworkCore;

namespace CarsAPI.Models
{
    public class CarContext : DbContext
    {
        public CarContext() { }
        public CarContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost; database=Cardb; user=root; password=rootpwd", ServerVersion.AutoDetect("server=localhost; database=Cardb; user=root; password=rootpwd"));
            }
        }
        public DbSet<Car> Cars { get; set; } = null!;
    }
}
