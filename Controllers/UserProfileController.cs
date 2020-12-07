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
        private readonly ILogger<UserProfileController> _logger;
        private readonly DatabaseContext _db;
        private readonly UserManager<AppUserModel> _user;

        public UserProfileController(ILogger<UserProfileController> logger, UserManager<AppUserModel> user, DatabaseContext db)
        {
            _logger = logger;
            _user = user;
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult> UpdateProfile(UserProfileViewModel userProfileViewModel)
        {
            string userid = _user.GetUserId(HttpContext.User);

            var user = _user.FindByIdAsync(userid).Result;
            user.PhoneNumber = userProfileViewModel.user.PhoneNumber;
            user.street = userProfileViewModel.user.street;
            user.state = userProfileViewModel.user.state;
            user.city = userProfileViewModel.user.city;
            user.postcode = userProfileViewModel.user.postcode;

            IdentityResult result = await _user.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("HomePage", "Home");
            }
            return View(userProfileViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UserProfile(UserProfileViewModel userProfileViewModel)
        {
            string username = User.FindFirstValue(ClaimTypes.Name);
            string userid = _user.GetUserId(HttpContext.User);
            userProfileViewModel.issued_books = await _db.book_issue.Where(b => b.member_id.Contains(username)).ToListAsync();
            userProfileViewModel.user = _user.FindByIdAsync(userid).Result;
            return View(userProfileViewModel);
        }
    }
}
