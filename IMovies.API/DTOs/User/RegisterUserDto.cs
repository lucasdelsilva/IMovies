using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IMovies.API.DTOs.User
{
    public class RegisterUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$",
            ErrorMessage = "A senha deve ter entre 6 e 20 caracteres e conter ao menos uma letra maiúscula, uma letra minúscula, um dígito e um caractere especial.")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [DefaultValue("dd/mm/yyyy")]
        public DateTime Birthday { get; set; }
    }
}