using ApiExamenPrueba.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenPrueba.Data
{
    public class CubosContext : DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options): base(options){}
        public DbSet<Cubo> Cubos { get; set; }
    }
}
