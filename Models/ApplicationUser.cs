using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Assignment1_v3.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(30, ErrorMessage = "{0} must be between {2} and {1} characters."), MinLength(2)]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(30, ErrorMessage = "{0} must be between {2} and {1} characters."), MinLength(2)]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [NotMapped]
        public string FullName {
            get {
                return $"{FirstName} {LastName}";
            }
        }

        [Display(Name = "GUID signature")]
        public String? SignatureGUID { get; set; } = Guid.NewGuid().ToString();
        public List<Resolution>? Resolutions { get; set; }
    }

}