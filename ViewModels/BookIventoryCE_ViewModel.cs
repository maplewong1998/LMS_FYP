using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.ViewModels
{
    public class BookIventoryCE_ViewModel
    {
        [Key]
        [Required(ErrorMessage = "*This field is required")]
        public string id { get; set; }
        [Required(ErrorMessage = "*This field is required")]
        public string book_name { get; set; }
        public string genre { get; set; }
        public string author_name { get; set; }
        public string publisher_name { get; set; }
        public string publish_date { get; set; }
        public string language { get; set; }
        public string edition { get; set; }
        public decimal book_cost { get; set; }
        public Int16 no_of_pages { get; set; }
        public string book_description { get; set; }
        [Required(ErrorMessage = "*This field is required")]
        public int actual_stock { get; set; }
        public int issued_books { get; set; }
        public string book_img { get; set; }
        public IFormFile book_pic { get; set; }
    }
}
