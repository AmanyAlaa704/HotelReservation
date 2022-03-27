using BL.StaticClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class RegisterDto
    {
        public string ID { get; set; }
        [Required]
        public string NationalID { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_ ]*$")]
        public string UserName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required]
        public string PasswordHash { get; set; }

        [Compare("PasswordHash")]
        public string ConfirmPassword { get; set; }

        public string RoleName { get; set; } 
    }
}
