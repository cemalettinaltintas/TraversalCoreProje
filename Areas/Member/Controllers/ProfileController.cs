﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Member.Models;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);

            UserEditViewModel userEditViewModel=new UserEditViewModel();
            userEditViewModel.Name=value.Name;
            userEditViewModel.Surname=value.Surname;
            userEditViewModel.PhoneNumber=value.PhoneNumber;
            userEditViewModel.Mail = value.Email;

            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Image!= null) 
            { 
                var resource=Directory.GetCurrentDirectory();
                var extension=Path.GetExtension(p.Image.FileName);
                //resim ismini guid üzerinden alıyoruz. Çakışmaması için
                var imageName=Guid.NewGuid()+extension;
                var saveLocation=resource+"/wwwroot/userimages/"+imageName;
                var stream=new FileStream(saveLocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                user.ImageUrl = imageName;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PhoneNumber = p.PhoneNumber;
            user.PasswordHash=_userManager.PasswordHasher.HashPassword(user,p.Password);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();

        }
    }
}
