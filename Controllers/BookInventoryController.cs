using LMS.Models;
using LMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace LMS.Controllers
{
    public class BookInventoryController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookInventoryController(DatabaseContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> BookInventory()
        {
            return View(await _db.book.ToListAsync());
        }

        [HttpGet]
        public IActionResult BookInventory_Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookInventory_Create(BookIventoryCE_ViewModel book)
        {
            if (ModelState.IsValid)
            {
                BookModel savebook = new BookModel
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
                    issued_books = 0,
                    book_img = UploadFile(book.book_pic)
                };
                _db.Add(savebook);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(BookInventory));
            }
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> BookInventory_Edit(string id)
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
        public async Task<IActionResult> BookInventory_Edit(string id, BookIventoryCE_ViewModel book)
        {
            if (id != book.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    BookModel savebook;
                    if (book.book_pic != null)
                    {
                        savebook = new BookModel
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
                            book_img = UploadFile(book.book_pic)
                        };
                    }
                    else
                    {
                        savebook = new BookModel
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
                        };
                    }
                    
                    _db.Update(savebook);
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
                return RedirectToAction(nameof(BookInventory));
            }
            return View(book);
        }

        private bool BookExists(string Id)
        {
            return _db.book.Any(e => e.id == Id);
        }

        private string UploadFile(IFormFile ifile)
        {
            string img_name = null;            
            if (ifile != null)
            {
                string imgext = Path.GetExtension(ifile.FileName);
                if (imgext == ".jpg" || imgext == ".gif")
                {
                    string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "lib/resources/books");
                    img_name = Guid.NewGuid().ToString() + "_" + ifile.FileName;
                    string filePath = Path.Combine(uploadFolder, img_name);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        ifile.CopyTo(fileStream);
                    }
                }
            }
            return img_name;
        }
    }
}
