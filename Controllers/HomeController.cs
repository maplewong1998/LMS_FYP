using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using LMS.Models;
using LMS.ViewModels;
using Microsoft.AspNetCore.Identity;
using LMS.Areas.Identity.Models;

namespace LMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly UserManager<AppUserModel> _user;

        public HomeController(UserManager<AppUserModel> user, DatabaseContext db)
        {
            _user = user;
            _db = db;
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult HomePage()
        {
            return View();
        }

        public async Task<IActionResult> Library()
        {
            return View(await _db.book.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Library_Borrow(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookModel book = await _db.book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            BookIventoryCE_ViewModel pass = new BookIventoryCE_ViewModel
            {
                id = book.id,
                book_name = book.book_name,
                genre = book.genre,
                author_name = book.author_name,
                publisher_name = book.publisher_name,
                publish_date = book.publish_date,
                language = book.language,
                edition = book.edition,
                book_cost = book.book_cost,
                no_of_pages = book.no_of_pages,
                book_description = book.book_description,
                actual_stock = book.actual_stock,
                issued_books = book.issued_books,
                book_img = book.book_img,
                book_pic = null
            };

            return View(pass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Library_Borrow(string id, BookIventoryCE_ViewModel book)
        {
            if (id != book.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    BookIssueModel newIssue = new BookIssueModel
                    {
                        id = DateTime.Now.ToString("yyyyMMddHHmmss"),
                        member_email = _user.GetUserName(HttpContext.User),
                        book_id = id,
                        issue_date = null,
                        due_date = null,
                        issue_status = "Pending"
                    };
                    _db.Add(newIssue);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Library));
            }
            return View(book);
        }

        private bool BookExists(string Id)
        {
            return _db.book.Any(e => e.id == Id);
        }
    }
}
