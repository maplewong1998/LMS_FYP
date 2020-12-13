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
    public class BookIssuingController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly AuthContext _authdb;

        public BookIssuingController(DatabaseContext db, AuthContext authdb)
        {
            _db = db;
            _authdb = authdb;
        }

        [HttpGet]
        public async Task<IActionResult> BookIssuing(BookIssueModel bookIssueModel)
        {
            return View(await _db.book_issue.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> BookIssuing_Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookIssueModel issue = await _db.book_issue.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            BookIssuingE_ViewModel pass = new BookIssuingE_ViewModel
            {
                id = issue.id,
                member_email = issue.member_email,
                book_id = issue.book_id,
                issue_date = issue.issue_date,
                due_date = issue.due_date,
                issue_status = issue.issue_status,
                member_name = _authdb.Users.Where(u => u.UserName == issue.member_email).Select(u => u.full_name).FirstOrDefault(),
                book_name = _db.book.Where(b => b.id == issue.book_id).Select(b => b.book_name).FirstOrDefault()
            };

            return View(pass);
        }
    }
}
