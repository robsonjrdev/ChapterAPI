using ChapterAPI.Contexts;
using ChapterAPI.Interfaces;
using ChapterAPI.Models;

namespace ChapterAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //variável privada criada para armazenar os dados do context
        private readonly ChapterContext _chapterContext;

        //injeção de dependência: o repository depende do context
        public UsuarioRepository(ChapterContext context)
        {
            _chapterContext = context;//armazenamento das informações do context dentro da variável privada
        }

       
        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioBuscado = _chapterContext.Usuarios.Find(id);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
             

                _chapterContext.Usuarios.Update(usuarioBuscado);
                _chapterContext.SaveChanges();
            }
        }

    
        public Usuario BuscarPorId(int id)
        {
            return _chapterContext.Usuarios.Find(id);
        }

    
        public void Cadastrar(Usuario usuario)
        {
            _chapterContext.Usuarios.Add(usuario);
            _chapterContext.SaveChanges();
        }

   
        public void Deletar(int id)
        {
            Usuario usuarioBuscado = _chapterContext.Usuarios.Find(id);
            _chapterContext.Usuarios.Remove(usuarioBuscado);
            _chapterContext.SaveChanges();
        }


        public List<Usuario> Listar()
        {
            return _chapterContext.Usuarios.ToList();
        }


        public Usuario Login(string email, string senha)
        {
            return _chapterContext.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

      
    }
}
