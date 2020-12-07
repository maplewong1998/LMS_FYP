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
    public class BookInventoryController : Controller
    {
        private readonly ILogger<BookInventoryController> _logger;
        private readonly DatabaseContext _db;

        public BookInventoryController(ILogger<BookInventoryController> logger, DatabaseContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult> BookInventoryForm(BookInventoryViewModel bookInventoryViewModel)
        {
            return View(bookInventoryViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> BookInventory(BookInventoryViewModel bookInventoryViewModel)
        {
            bookInventoryViewModel.book_list = await _db.book.ToListAsync();

            return View(bookInventoryViewModel);
        }
    }
}
