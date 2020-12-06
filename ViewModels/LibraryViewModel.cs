using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.ViewModels
{
    public class LibraryViewModel
    {
        public IEnumerable<BookModel> book_list { get; set; }
    }
}
