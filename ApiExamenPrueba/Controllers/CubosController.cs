using ApiExamenPrueba.Models;
using ApiExamenPrueba.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamenPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubosController : ControllerBase
    {
        private RepositoryCubos repo;

        public CubosController(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cubo>>> GetCubos()
        {
            return await this.repo.GetCubosAsync();
        }

        [HttpGet]
        [Route("CubosPrecio/{precio}")]
        public async Task<ActionResult<List<Cubo>>> GetCubosPrecio(int precio)
        {
            return await this.repo.GetCuboPrecioASync(precio);
        }

        [HttpGet]
        [Route("Marcas")]
        public async Task<ActionResult<List<string>>> GetMarcas()
        {
            return await this.repo.GetMarcasAsync();
        }

        [HttpGet]
        [Route("{idCubo}")]
        public async Task<ActionResult<Cubo>> FindCubo(int idCubo)
        {
            return await this.repo.FindCuboAsync(idCubo);
        }

        [HttpPost]
        [Route("CreateCubo")]
        public async Task<ActionResult> CreateCubo(Cubo cubo)
        {
            await this.repo.CreateCuboAsync(cubo);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateCubo")]
        public async Task<ActionResult> UpdateCubo(Cubo cubo)
        {
            await this.repo.UpdateCuboAsync(cubo);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteCubo/{idCubo}")]
        public async Task<ActionResult> DeleteCubo(int idCubo)
        {
            if (await this.repo.FindCuboAsync(idCubo) == null)
            {
                return NotFound();
            }else
            {
                await this.repo.DeleteCuboASync(idCubo);
                return Ok();
            }
            
        }
    }
}
