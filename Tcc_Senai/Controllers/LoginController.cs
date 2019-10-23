

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tcc_Senai.Models;

namespace Tcc_Senai.Controllers
{
    public class LoginController : Controller
    {

       /* public class AccountController : Controller
        {
            private readonly SignInManager<IdentityUser> signInManager;

            public AccountController(SignInManager<IdentityUser> signInManager)
            {
                this.signInManager = signInManager;
            }

            [HttpPost]
            public async Task<IActionResult> Logout()
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("index", "home");
            }

            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Login(Login model)
            {
                if (ModelState.IsValid)
                {
                    var result = await signInManager.PasswordSignInAsync(
                        model.Email, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }

                return View(model);
            }
        */}
    }
