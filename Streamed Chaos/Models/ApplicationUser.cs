using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Streamed_Chaos.Models
{
    public class ApplicationUser : IdentityUser
    {
        // This is creating a column
        //[CustomProfilePicture]
        [PersonalData]
        [StringLength(75)]
        public string ProfilePicture { get; set; } = null!;
    }

    public class CustomProfilePicture : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Custom logic goes here
            throw new NotImplementedException();
        }
    }
}
