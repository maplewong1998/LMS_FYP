using LMS.Areas.Identity.Models;
using LMS.Models;
using LMS.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly UserManager<AppUserModel> _user;

        public UserProfileController(UserManager<AppUserModel> user, DatabaseContext db)
        {
            _user = user;
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult> UpdateProfile(UserProfileViewModel userProfileViewModel)
        {
            if(ModelState.IsValid)
            {
                string username = User.FindFirstValue(ClaimTypes.Name);
                string userid = _user.GetUserId(HttpContext.User);
                userProfileViewModel.issued_books = await _db.book_issue.Where(b => b.member_email.Contains(username)).ToListAsync();
                var user = _user.FindByIdAsync(userid).Result;
                user.PhoneNumber = userProfileViewModel.user.PhoneNumber;
                user.street = userProfileViewModel.user.street;
                user.state = userProfileViewModel.user.state;
                user.city = userProfileViewModel.user.city;
                user.postcode = userProfileViewModel.user.postcode;

                await _user.UpdateAsync(user);
            }            
            
            return View("UserProfile", userProfileViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UserProfile()
        {
            UserProfileViewModel userProfileViewModel = new UserProfileViewModel();
            string username = User.FindFirstValue(ClaimTypes.Name);
            string userid = _user.GetUserId(HttpContext.User);
            userProfileViewModel.issued_books = await _db.book_issue.Where(b => b.member_email.Contains(username)).ToListAsync();
            userProfileViewModel.user = _user.FindByIdAsync(userid).Result;
            return View(userProfileViewModel);
        }
    }
}
