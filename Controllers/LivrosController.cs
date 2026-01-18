using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8_Video.Models;
using WebApi8_Video.Services.Livro;

namespace WebApi8_Video.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;


        public LivrosController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorId")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(string IdLivro)
        {
            var livros = await _livroInterface.BuscarLivroPorId(IdLivro);
            return Ok(livros);
        }
    }
}