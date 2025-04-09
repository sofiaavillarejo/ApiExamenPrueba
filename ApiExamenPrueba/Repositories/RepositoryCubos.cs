using ApiExamenPrueba.Data;
using ApiExamenPrueba.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenPrueba.Repositories
{
    public class RepositoryCubos
    {
        private CubosContext context;

        public RepositoryCubos(CubosContext context)
        {
            this.context = context;
        }

        public async Task<List<Cubo>> GetCubosAsync()
        {
            return await this.context.Cubos.ToListAsync();
        }

        public async Task<List<Cubo>> GetCuboPrecioASync(int precio)
        {
            return await this.context.Cubos.Where(c => c.Precio == precio).ToListAsync();
        }

        public async Task<List<string>> GetMarcasAsync()
        {
            return await this.context.Cubos.Select(c => c.Marca).Distinct().ToListAsync();
        }

        public async Task<Cubo> FindCuboAsync(int idCubo)
        {
            return await this.context.Cubos.FirstOrDefaultAsync(c => c.IdCubo == idCubo);
        }

        private async Task<int> GetMaxIdCubo()
        {
            if (!await this.context.Cubos.AnyAsync())
            {
                return 1;
            }
            else
            {
                return await this.context.Cubos.MaxAsync(c => c.IdCubo) + 1;
            }
        }

        public async Task CreateCuboAsync(Cubo c)
        {
            c.IdCubo = await this.GetMaxIdCubo();
            await this.context.Cubos.AddAsync(c);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateCuboAsync(Cubo c)
        {
            Cubo cubo = await FindCuboAsync(c.IdCubo);
            cubo.Nombre = c.Nombre;
            cubo.Modelo = c.Modelo;
            cubo.Marca = c.Marca;
            cubo.Imagen = c.Imagen;
            cubo.Precio = c.Precio;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteCuboASync(int idCubo)
        {
            Cubo cubo = await FindCuboAsync(idCubo);
            this.context.Cubos.Remove(cubo);
            await this.context.SaveChangesAsync();
        }
    }
}
