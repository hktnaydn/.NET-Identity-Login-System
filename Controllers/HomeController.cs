using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcoreıdentyegitim.Models;
using aspnetcoreıdentyegitim.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoreıdentyegitim.Controllers
{
    public class HomeController : Controller
    {

        public UserManager<AppUser> userManager { get; }

        public SignInManager<AppUser> signInManager { get; }
        public HomeController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel userLogin)
        {
            if(ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(userLogin.Email);

                if(user!=null)
                {

                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result= await signInManager.PasswordSignInAsync(user,userLogin.Password,false,false);

                    if(result.Succeeded )
                    {
                        return RedirectToAction("Index", "Member");
                    }
                 
                }
                else
                {
                    ModelState.AddModelError("", "Geçersiz Bilgiler");
                }
            }


            return View();
        }
        public IActionResult SıgnUp()
        {
            return View();
        }
        [HttpPost]
           public async Task< IActionResult> SıgnUp(UserViewModel userViewModel)
        {

            if(ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.UserName = userViewModel.UserName;
                user.Email= userViewModel.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;
               IdentityResult result=  await  userManager.CreateAsync(user,userViewModel.Password);

                if(result.Succeeded)
                {
                    return RedirectToAction("LogIn"); 
                }
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }

                }

            }


            return View(userViewModel);
        }
    }
}
