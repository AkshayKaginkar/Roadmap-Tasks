
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Session5.Context
{
    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "First Name is Mandatory, Fill it")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Mandatory, Fill it")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter Your City")]
        public string City { get; set; }
    }
}
