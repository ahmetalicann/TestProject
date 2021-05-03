﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.MvcWebUI.Identity;
using TestProject.MvcWebUI.Models.Security;

namespace TestProject.MvcWebUI.Controllers
{
    public class SecurityController : Controller
    {
        private UserManager<AppIdentityUser> _userManager;
        private RoleManager<AppIdentityRole> _roleManager;
        private SignInManager<AppIdentityUser> _signInManager;
        private IConfiguration _configuration;

        public SecurityController(UserManager<AppIdentityUser> userManager, RoleManager<AppIdentityRole> roleManager, SignInManager<AppIdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async IActionResult Login(LoginViewModel loginViewModel, string returnUrl = "")
        {
            //_userManager kullanıcıyı bulma confirmleri kontrol etme gibi işlemler yaparken _signInManager login işlemlerini gerçekleştiriyor.
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user != null)
                {
                    //kullanıcının mailine confirmation gitti ve onaylandı mı kontrolü.
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        //Eğer onaylanmış mail değilse uyarı veriyor ve sayfayı döndürüyor.
                        ModelState.AddModelError(string.Empty, "Confirm your Email please!");
                        return View(loginViewModel);
                    }
                    //Login işlemi için userdan maili loginViewModelden passwordu alıyor ve eğer başarılıysa hangi url yönlendirdiysek oraya gidiyor.
                    //eğer doğru değilsede Uyarı veriyor.
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, true);
                    if (result.Succeeded)
                    {
                        if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return RedirectToAction(returnUrl);
                        }
                        else
                        {
                            return View(loginViewModel);
                        }
                    }
                    ModelState.AddModelError(String.Empty, "Login Failed!");
                    return View(loginViewModel);
                }
                return View(loginViewModel);
            }
            return View(loginViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new AppIdentityUser
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.UserName
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    //Bu kısımda kullancıya yollanan emaile tıkladıgı zaman bir code gelicek ve biz o kodu kontrol ederek onay vericez.
                    var confirmationCode = _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var projectUrl = _configuration.GetSection("ProjectSettings").GetSection("ProjectUrl").Value;
                    var callBackUrl = projectUrl + Url.Action("ConfirmEmail", "Security", new { userId = user.Id, code = confirmationCode.Result });

                    //Kullancııya mail gönderme.

                    return RedirectToAction("ConfirmEmailInfo","Security",new { email = user.Email});
                }
                return View(registerViewModel);
            }
            return View(registerViewModel);
        }

        public IActionResult ConfirmEmailInfo(string email)
        {
            TempData["email"] = email;
            return View();
        }
    }
}
