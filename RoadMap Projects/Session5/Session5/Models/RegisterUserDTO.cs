using System.ComponentModel.DataAnnotations;

namespace Session5.Models
{
    public class RegisterUserDTO
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
