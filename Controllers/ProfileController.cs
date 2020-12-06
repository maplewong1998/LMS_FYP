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
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly DatabaseContext _db;
        private readonly AuthContext _authdb;
        private readonly UserManager<AppUserModel> _user;
        private UserProfileViewModel userProfileViewModel = new UserProfileViewModel();

        public ProfileController(ILogger<ProfileController> logger, UserManager<AppUserModel> user, DatabaseContext db, AuthContext authdb)
        {
            _logger = logger;
            _user = user;
            _db = db;
            _authdb = authdb;
        }

        public async Task<IActionResult> UserProfile()
        {
            String username = User.FindFirstValue(ClaimTypes.Name);
            String userid = _user.GetUserId(HttpContext.User);
            userProfileViewModel.issued_books = await _db.book_issue.Where(b => b.member_id.Contains(username)).ToListAsync();
            userProfileViewModel.user = _user.FindByIdAsync(userid).Result;
            return View(userProfileViewModel);
        }
    }
}
