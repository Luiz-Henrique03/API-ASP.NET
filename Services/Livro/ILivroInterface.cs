using WebApi8_Video.Models;

namespace WebApi8_Video.Services.Livro
{
    public interface ILivroInterface
    {

        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(string idLivro);

        Task<ResponseModel<List<LivroModel>>> ExcluirLivro(string idLivro);
    }
}
