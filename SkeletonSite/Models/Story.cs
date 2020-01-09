using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SkeletonSite.Models
{
    public class Story
    {
        public int StoryID { get; set; }
        public List<Comment> com = new List<Comment>();
        [Required(ErrorMessage = "Please input a title for your story")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please input some text for your story")]
        public string Text { get; set; }

        public List<Comment> Subjects { get { return com; } }
    }
}
