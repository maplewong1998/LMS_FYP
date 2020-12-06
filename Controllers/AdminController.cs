using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMS.ViewModels;
using Microsoft.AspNetCore.Identity;
using LMS.Areas.Identity.Models;

namespace LMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly DatabaseContext _db;
        private readonly AuthContext _authdb;

        public AdminController(ILogger<AdminController> logger, DatabaseContext db, AuthContext authdb)
        {
            _logger = logger;
            _db = db;
            _authdb = authdb;
        }

        public async Task<IActionResult> BookInventory(BookInventoryViewModel bookInventoryViewModel)
        {
            bookInventoryViewModel.book_list = await _db.book.ToListAsync();

            return View(bookInventoryViewModel);
        }

        public async Task<IActionResult> MemberManagement(MemberManagementViewModel memberManagementViewModel)
        {
            memberManagementViewModel.user_list = await _authdb.Users.ToListAsync();

            return View(memberManagementViewModel);
        }

        public async Task<IActionResult> BookIssuing(BookIssuingViewModel bookIssuingViewModel)
        {
            bookIssuingViewModel.issue_list = await _db.book_issue.ToListAsync();

            return View(bookIssuingViewModel);
        }
    }
}
