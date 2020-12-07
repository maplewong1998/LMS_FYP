using LMS.Areas.Identity.Models;
using LMS.Models;
using LMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    public class MemberManagementController : Controller
    {
        private readonly ILogger<MemberManagementController> _logger;
        private readonly AuthContext _authdb;

        public MemberManagementController(ILogger<MemberManagementController> logger, AuthContext authdb)
        {
            _logger = logger;
            _authdb = authdb;
        }

        [HttpGet]
        public async Task<IActionResult> MemberManagement(MemberManagementViewModel memberManagementViewModel)
        {
            memberManagementViewModel.user_list = await _authdb.Users.ToListAsync();

            return View(memberManagementViewModel);
        }
    }
}
