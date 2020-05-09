using System;
using Microsoft.EntityFrameworkCore;

namespace cars_api_example.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            :base(options) // TODO ask about the usage here
        {
        }

        public DbSet<CarItem> CarItems { get; set; }
    }
}
