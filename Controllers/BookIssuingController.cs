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
        private readonly ILogger<BookIssuingController> _logger;
        private readonly DatabaseContext _db;

        public BookIssuingController(ILogger<BookIssuingController> logger, DatabaseContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> BookIssuing(BookIssuingViewModel bookIssuingViewModel)
        {
            bookIssuingViewModel.issue_list = await _db.book_issue.ToListAsync();

            return View(bookIssuingViewModel);
        }
    }
}
