using LMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.ViewModels
{
    public class BookInventoryViewModel
    {
        public BookModel add_book { get; set; }
        public IEnumerable<BookModel> book_list { get; set; }
        public List<SelectListItem> genre_list { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Action", Text = "Action" },
            new SelectListItem { Value = "Adventure", Text = "Adventure" },
            new SelectListItem { Value = "Comic Book", Text = "Comic Book" },
            new SelectListItem { Value = "Self Help", Text = "Self Help" },
            new SelectListItem { Value = "Motivation", Text = "Motivation" },
            new SelectListItem { Value = "Healthy Living", Text = "Healthy Living" },
            new SelectListItem { Value = "Wellness", Text = "Wellness" },
            new SelectListItem { Value = "Crime", Text = "Crime" },
            new SelectListItem { Value = "Drama", Text = "Drama" },
            new SelectListItem { Value = "Fantasy", Text = "Fantasy" },
            new SelectListItem { Value = "Horror", Text = "Horror" },
            new SelectListItem { Value = "Poetry", Text = "Poetry" },
            new SelectListItem { Value = "Personal Development", Text = "Personal Development" },
            new SelectListItem { Value = "Romance", Text = "Romance" },
            new SelectListItem { Value = "Science Fiction", Text = "Science Fiction" },
            new SelectListItem { Value = "Suspense", Text = "Suspense" },
            new SelectListItem { Value = "Thriller", Text = "Thriller" },
            new SelectListItem { Value = "Art", Text = "Art" },
            new SelectListItem { Value = "Autobiography", Text = "Autobiography" },
            new SelectListItem { Value = "Encyclopedia", Text = "Encyclopedia" },
            new SelectListItem { Value = "Health", Text = "Health" },
            new SelectListItem { Value = "History", Text = "History" },
            new SelectListItem { Value = "Math", Text = "Math" },
            new SelectListItem { Value = "Textbook", Text = "Textbook" },
            new SelectListItem { Value = "Science", Text = "Science" },
            new SelectListItem { Value = "Travel", Text = "Travel" },
            new SelectListItem { Value = "Philosophy", Text = "Philosophy" }
        };
        public List<SelectListItem> language_list { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "English", Text = "English" },
            new SelectListItem { Value = "Malay", Text = "Malay" },
            new SelectListItem { Value = "Chinese", Text = "Chinese" },
            new SelectListItem { Value = "Hindi", Text = "Hindi" }
        };
    }
}
