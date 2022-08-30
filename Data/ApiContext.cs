using Microsoft.EntityFrameworkCore;
using ColoursAPI.Models;

namespace ColoursAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Colour> Colours { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        { 
        
        }
    }
}
