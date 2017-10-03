using System.ComponentModel.DataAnnotations;

namespace Mimilo.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="La direccion de email es obligatoria")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage="La direccion de email no tiene un formato valido")]
        public string Email { get; set; }

        [Required(ErrorMessage="La constraseña de email es obligatoria")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}