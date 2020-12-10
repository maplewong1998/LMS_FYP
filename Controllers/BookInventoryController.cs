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
        private readonly DatabaseContext _db;

        public BookInventoryController(DatabaseContext db)
        {
            _db = db;
        }

        /*[HttpPost]
        public async Task<ActionResult> BookInventoryForm(BookInventoryViewModel bookInventoryViewModel, string submit)
        {
            bookInventoryViewModel.book_list = await _db.book.ToListAsync();
            var query = _db.book.Single(b => b.id == bookInventoryViewModel.book_form.id);

            switch (submit)
            {
                case "search":
                    bookInventoryViewModel.book_form = query;
                    bookInventoryViewModel.current_stock = query.actual_stock - query.issued_books;
                    break;

                case "add":
                    break;

                case "update":
                    query.book_name = bookInventoryViewModel.book_form.book_name;
                    query.language = bookInventoryViewModel.book_form.language;
                    query.genre = bookInventoryViewModel.book_form.genre;
                    query.author_name = bookInventoryViewModel.book_form.author_name;
                    query.publisher_name = bookInventoryViewModel.book_form.publisher_name;
                    query.publish_date = bookInventoryViewModel.book_form.publish_date;
                    query.edition = bookInventoryViewModel.book_form.edition;
                    query.book_cost = bookInventoryViewModel.book_form.book_cost;
                    query.no_of_pages = bookInventoryViewModel.book_form.no_of_pages;
                    query.actual_stock = bookInventoryViewModel.book_form.actual_stock;
                    query.book_description = bookInventoryViewModel.book_form.book_description;
                    await _db.SaveChangesAsync();
                    break;

                case "delete":
                    _db.Remove(query);
                    await _db.SaveChangesAsync();
                    break;
            }

            return View("BookInventory", bookInventoryViewModel);
        }*/

        [HttpGet]
        public async Task<IActionResult> BookInventory()
        {
            return View(await _db.book.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> BookInventory_Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _db.book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
    }
}
