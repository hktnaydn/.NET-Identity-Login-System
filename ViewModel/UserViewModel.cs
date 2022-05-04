using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreıdentyegitim.ViewModel
{
    public class UserViewModel
    {

        [Required(ErrorMessage = "Kullanıcı ismi Gereklidir")]
        [Display(Name="Kullanıcı Adı")]
        public string UserName { get; set; }


       
        [Display(Name = "Tel no")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Gereklidir")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Yanlış Format Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Gereklidir")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
