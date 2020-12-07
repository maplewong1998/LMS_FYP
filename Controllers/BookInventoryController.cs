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
        public async Task<ActionResult> BookInventoryForm(BookInventoryViewModel bookInventoryViewModel, string submit)
        {
            switch(submit)
            {
                case "search":
                    bookInventoryViewModel.add_book = _db.book.Single(b => b.book_id.Contains(bookInventoryViewModel.add_book.book_id));
                    break;

                case "add":
                    break;

                case "update":
                    var query = (from books in _db.book
                                where books.book_id == bookInventoryViewModel.add_book.book_id
                                select books).First();
                    query.book_name = bookInventoryViewModel.add_book.book_name;
                    query.language = bookInventoryViewModel.add_book.language;
                    query.author_name = bookInventoryViewModel.add_book.author_name;
                    query.publisher_name = bookInventoryViewModel.add_book.publisher_name;
                    query.publish_date = bookInventoryViewModel.add_book.publish_date;
                    query.edition = bookInventoryViewModel.add_book.edition;
                    query.book_cost = bookInventoryViewModel.add_book.book_cost;
                    query.actual_stock = bookInventoryViewModel.add_book.actual_stock;
                    query.book_description = bookInventoryViewModel.add_book.book_description;

                    await _db.SaveChangesAsync();

                    break;

                case "delete":
                    break;
            }
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
