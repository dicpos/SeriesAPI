using Microsoft.EntityFrameworkCore;
using SeriesAPI.Models;

namespace SeriesApi.Data
{
    public class SerieContext : DbContext
    {
        public SerieContext(DbContextOptions<SerieContext> opt) : base(opt)
        {

        }

        public DbSet<Serie> Series { get; set; }

    }
}