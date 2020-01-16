using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SkeletonSite.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please input a username for your account")]
        [StringLength(50, MinimumLength = 2)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please input an example email, not your real email.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
