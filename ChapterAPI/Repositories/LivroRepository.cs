using ChapterAPI.Contexts;
using ChapterAPI.Interfaces;
using ChapterAPI.Models;

namespace ChapterAPI.Repositories
{

    public class LivroRepository : ILivroRepository
    {
        //variável privada criada para armazenar os dados do context
        private readonly ChapterContext _chapterContext;

        //injeção de dependência: o repository depende do context
        public LivroRepository(ChapterContext context)
        {
            _chapterContext = context;
        }

        public void Atualizar(int id, Livro livro)
        {
            Livro livroBuscado = _chapterContext.Livros.Find(id);

            if (livroBuscado != null)
            {
                livroBuscado.Titulo = livro.Titulo;
                livroBuscado.QuantidadePaginas = livro.QuantidadePaginas;
                livroBuscado.Disponivel = livro.Disponivel;
            }
            _chapterContext.Livros.Update(livroBuscado);
            _chapterContext.SaveChanges();
        }

        public Livro BuscarPorId(int id)
        {
            return _chapterContext.Livros.Find(id);
        }

        public Livro BuscarPorTitulo(string titulo)
        {
            return _chapterContext.Livros.Find(titulo);
        }

        public void Cadastrar(Livro livro)
        {
            _chapterContext.Livros.Add(livro);
            _chapterContext.SaveChanges();
        }

        public void Deletar(int id)
        {
            Livro livro = _chapterContext.Livros.Find(id);
            _chapterContext.Livros.Remove(livro);
            _chapterContext.SaveChanges();
        }

        //método implementado da interface
        public List<Livro> Ler()
        {
            return _chapterContext.Livros.ToList();
        }
    }
}
