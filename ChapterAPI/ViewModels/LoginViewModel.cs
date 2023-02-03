using System.ComponentModel.DataAnnotations;

namespace ChapterAPI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O E-mail é obrigatório!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória!")]
        public string? Senha { get; set; }
    }
}
