using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkeletonSite.Models;

namespace SkeletonSite.Repositories
{
    public class FakeStoriesRepository : IRepository
    {
        public static List<Story> stories = new List<Story>();
        public static List<User> users = new List<User>();

        public List<Story> Stories { get { return stories; } }
        public List<User> Users { get { return users; } }

        public void AddStory(Story story)
        {
            stories.Add(story);
        }

        public void AddComment(Comment com, string title)
        {
            Retrieve(title).Subjects.Add(com);
        }

        public void AddUser(User use)
        {
            users.Add(use);
        }

        public Story Retrieve(string title)
        {
            return stories.Find(x => x.Title == title);
        }

       public void AddInitialData()
        {
            Story s1 = new Story { Title = "King of Grapes", Text = "He owned a lot of grapes" };
            Story s2 = new Story { Title = "King of Bananas", Text = "He owned a lot of bananas"};
            Story s3 = new Story { Title = "King of Apples", Text = "He owned a lot of apples" };
            stories.Add(s1);
            stories.Add(s2);
            stories.Add(s3);
            User u1 = new User { UserName = "The king", Email = "coolguy@wowies.com" };
            users.Add(u1);
        }
    }
}
