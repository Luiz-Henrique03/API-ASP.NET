using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8_Video.Dto.Autor;
using WebApi8_Video.Models;
using WebApi8_Video.Services.Autor;

namespace WebApi8_Video.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {

        private readonly IAutorInterface _autorInterface;

        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("ListarAutores")]

        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorId/{IdAutor}")]

        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(string  IdAutor) 
        {
            var autor = await _autorInterface.BuscarAutorPorId(IdAutor);
            return Ok(autor);
        }

        [HttpGet("BuscarAutorPorIdLivro/{IdLivro}")]

        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(string IdLivro)
        {
            var autor = await _autorInterface.BuscarAutorPorIdLivro(IdLivro);
            return Ok(autor);
        }


        [HttpPost("CriarAutor")]

        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var autores = await _autorInterface.CriarAutor(autorCriacaoDto);
            return Ok(autores);
        }

        [HttpPut("EditarAutor")]

        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            var autores = await _autorInterface.EditarAutores(autorEdicaoDto);
            return Ok(autores);
        }

        [HttpDelete("ExcluirAutor")]

        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ExcluirAutor(string IdAutor)
        {
            var autores = await _autorInterface.ExcluirAutor(IdAutor);
            return Ok(autores);
        }
    }
}
