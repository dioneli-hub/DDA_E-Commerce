using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDA.ApiModels
{
    public class ChangePasswordModel
    {
        [Required, StringLength(100, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "The passwords do not match. Please, try again.")] 
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
