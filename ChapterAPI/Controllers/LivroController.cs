using ChapterAPI.Interfaces;
using ChapterAPI.Models;
using ChapterAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterAPI.Controllers
{
    [Produces("application/json")]//formato de reposta da api : json
    [Route("api/[controller]")]//rota para acesso do controller : api/livro
    [ApiController]//identificação que é uma classe controladora

    public class LivroController : ControllerBase//herança da classe ControllerBase
    {
        private readonly ILivroRepository _iLivroRepository;//variável privada criada para armazenar os dados do repositório

        public LivroController(ILivroRepository iLivroRepository)//injeção de dependência: o controller depende da interface
        {
            _iLivroRepository = iLivroRepository;//armazenamento das informações da interface dentro da variável privada
        }

      

     
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_iLivroRepository.Ler());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

   
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Livro livro = _iLivroRepository.BuscarPorId(id);

                if (livro == null)
                {
                    return NotFound();
                }
                return Ok(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        
        [HttpPost]
        [Authorize]
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _iLivroRepository.Cadastrar(livro);
                return Ok(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

   
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Livro livro)
        {
            try
            {
                _iLivroRepository.Atualizar(id, livro);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _iLivroRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       
        [HttpGet("titulo/{titulo}")]
        public IActionResult BuscarPorTitulo(string titulo)
        {
            try
            {
                Livro livro = _iLivroRepository.BuscarPorTitulo(titulo);

                if (livro == null)
                {
                    return NotFound();
                }
                return Ok(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }



       
    }
}
