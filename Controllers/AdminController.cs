using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcoreıdentyegitim.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoreıdentyegitim.Controllers
{
    public class AdminController : Controller
    {


        private UserManager<AppUser> userManager { get; }
        public AdminController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }



        public IActionResult Index()
        {
            return View(userManager.Users.ToList());
        }
    }
}
