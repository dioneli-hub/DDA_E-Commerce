using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDA.ApiModels
{
    public class RegisterUserModel
    {
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
