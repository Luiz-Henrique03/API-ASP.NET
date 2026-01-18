using Microsoft.EntityFrameworkCore;
using WebApi8_Video.Data;
using WebApi8_Video.Dto.Autor;
using WebApi8_Video.Models;

namespace WebApi8_Video.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(string idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();

            try
            {
                var Livro = await _context.Livros.FirstOrDefaultAsync(LivroBanco => LivroBanco.Id == idLivro);
                if (Livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado";
                }

                resposta.Dados = Livro;
                resposta.Mensagem = "Livro encontrado";


                return resposta;

            }catch (Exception ex)
            {
                return resposta;

            }

        }


        public Task<ResponseModel<List<LivroModel>>> ExcluirLivro(string idAutor)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livros.ToListAsync();
                resposta.Dados = livros;
                resposta.Mensagem = "Todos os dados foram coletatos";

                return resposta;

            }catch (Exception ex)
            {
                return resposta;
            }

        }
    }
}
