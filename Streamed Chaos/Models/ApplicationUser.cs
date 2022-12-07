using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Streamed_Chaos.Models
{
    public class ApplicationUser : IdentityUser
    {
        // This is creating a column
        //[CustomProfilePicture]
        //[PersonalData]
        public string ImagePath { get; set; }
    }

    /// <summary>
    /// Setting up the profile picture
    /// </summary>
    public class CustomProfilePicture : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
