using Microsoft.EntityFrameworkCore;
using WebApi8_Video.Data;
using WebApi8_Video.Dto.Autor;
using WebApi8_Video.Dto.Livro;
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
                var Livro = await _context.Livros
                            .Include(a => a.Autor)
                            .FirstOrDefaultAsync(LivroBanco => LivroBanco.Id == idLivro);
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

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroCriacaoDto.Autor.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "nenhum registro localizado";
                    return resposta;
                }

                var livro = new LivroModel()
                {
                    Id = livroCriacaoDto.Id,
                    Titulo = livroCriacaoDto.Titulo,
                    Autor = autor
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(a=> a.Autor).ToListAsync();
                resposta.Mensagem = "Autor criado com sucesso";

                return resposta;
            }
            catch (Exception ex)
            {
                // Se houver uma exceção interna (do SQL), pega ela. Se não, pega a genérica.
                resposta.Mensagem = ex.InnerException?.Message ?? ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == livroEdicaoDto.Id);
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroEdicaoDto.Autor.Id);

                if (livro  == null || autor == null) {
                    resposta.Mensagem = "Registro não encontrado";
                }

                livro.Titulo = livroEdicaoDto.Titulo;
                livro.Autor = autor;

                _context.Update(livro);

                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();

                return resposta;
               

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(string idLivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Livro autor localizado";
                    return resposta;
                }

                _context.Remove(livro);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Livro removido";

                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem= ex.Message;
                resposta.Status = false;

                return resposta;
            }

        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livros
                                    .Include(x => x.Autor) 
                                    .ToListAsync();

                resposta.Dados = livros;
                resposta.Mensagem = "Todos os dados foram coletados";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
