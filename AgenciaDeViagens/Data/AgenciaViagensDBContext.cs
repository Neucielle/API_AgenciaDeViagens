using AgenciaDeViagens.Data.Map;
using AgenciaDeViagens.Models;
using Microsoft.EntityFrameworkCore;

namespace AgenciaDeViagens.Data
{
    public class AgenciaViagensDBContext : DbContext
    {
        public AgenciaViagensDBContext(DbContextOptions<AgenciaViagensDBContext> options) 
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; } = null!;
        public DbSet<TravelModel> Travels { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TravelMap());   
            base.OnModelCreating(modelBuilder);
        }

    }
}
