using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreıdentyegitim.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name="Email Adresiniz")]
        [Required(ErrorMessage ="Email Alanı Gereklidir")]
        [EmailAddress]
        public string Email { get; set; }



        [Display(Name = "Şifreniz")]
        [Required(ErrorMessage = "Şifre Alanı Gereklidir")]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage ="Şifre en az 4 karakterlidir")]
        public string Password { get; set; }
    }
}
