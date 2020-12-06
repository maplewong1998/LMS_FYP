using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class BookModel
    {
        [Column(TypeName = "nvarchar(50)")]
        [Key]
        [Required]
        public String book_id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String book_name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String genre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String author_name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String publisher_name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String publish_date { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String language { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String edition { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        [Required]
        public decimal book_cost { get; set; }
        [Column(TypeName = "smallint")]
        [Required]
        public Int16 no_of_pages { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        [Required]
        public String book_description { get; set; }
        [Column(TypeName = "int")]
        [Required]
        public int actual_stock { get; set; }
        [Column(TypeName = "int")]
        public int issued_books { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public String book_img { get; set; }     
    }
}
