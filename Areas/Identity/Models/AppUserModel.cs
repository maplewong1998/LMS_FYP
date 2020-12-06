using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LMS.Areas.Identity.Models
{
    // Add profile data for application users by adding properties to the AppUserModel class
    public class AppUserModel : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public String full_name { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public String dob { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public String street { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public String state { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public String city { get; set; }

        [PersonalData]
        [Column(TypeName = "int")]
        public int postcode { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public String account_status { get; set; }
    }
}
