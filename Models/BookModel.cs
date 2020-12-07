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
        public string book_id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string book_name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string genre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string author_name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string publisher_name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string publish_date { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string language { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string edition { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        [Required]
        public decimal book_cost { get; set; }
        [Column(TypeName = "smallint")]
        [Required]
        public Int16 no_of_pages { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        [Required]
        public string book_description { get; set; }
        [Column(TypeName = "int")]
        [Required]
        public int actual_stock { get; set; }
        [Column(TypeName = "int")]
        public int issued_books { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string book_img { get; set; }     
    }
}
