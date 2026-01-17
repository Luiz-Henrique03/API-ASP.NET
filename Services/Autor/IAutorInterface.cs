using WebApi8_Video.Dto.Autor;
using WebApi8_Video.Models;

namespace WebApi8_Video.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(string idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(string idLivro);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto);

        Task<ResponseModel<List<AutorModel>>> EditarAutores(AutorEdicaoDto autorEdicaoDto);

        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(string idAutor);



    }
}
