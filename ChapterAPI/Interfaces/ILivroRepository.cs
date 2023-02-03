using ChapterAPI.Models;

namespace ChapterAPI.Interfaces
{
    /// <summary>
    /// Interface ILivroRepository
    /// </summary>
    public interface ILivroRepository
    {
        List<Livro> Ler();

        Livro BuscarPorId(int id);

        void Cadastrar(Livro livro);

        void Atualizar(int id, Livro livro);

        void Deletar(int id);

        Livro BuscarPorTitulo(string titulo);
    }
}
