using Backend_ApiNetCore3_1.Domain.Models;
using Backend_ApiNetCore3_1.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Backend_ApiNetCore3_1.Infra.Data.Context
{
    public class Backend_ApiNetCore3_1Context : DbContext
    {
        public Backend_ApiNetCore3_1Context(
            DbContextOptions<Backend_ApiNetCore3_1Context> options) : base(options) { }

        public DbSet<Position> Position { get; set; }

        public DbSet<Employee> Employees { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new AppUserMap());


            modelBuilder.ApplyConfiguration(new EmployeeMap());

            modelBuilder.ApplyConfiguration(new PositionMap());


            base.OnModelCreating(modelBuilder);
        }
    }
}
