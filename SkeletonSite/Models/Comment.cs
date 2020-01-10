using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SkeletonSite.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        [Required(ErrorMessage = "Please input your text for your comment")]
        [RegularExpression(@"^\w{2,100}$")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Please input a rating for the story")]
        [RegularExpression(@"^\d{1,2}&")]
        [Range(1, 10)]
        public int Rating { get; set; }
    }
}
