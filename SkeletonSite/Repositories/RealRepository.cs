using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkeletonSite.Models;
using Microsoft.EntityFrameworkCore;

namespace SkeletonSite.Repositories
{
    public class RealRepository : IRepository
    {
        public AppDbContext context;
        public List<Story> Stories { get { return context.Stories.Include(x => x.Subjects).ToList(); } }
        public List<User> Users { get { return context.Users.ToList(); } }

        public RealRepository(AppDbContext dbContext)
        {
            context = dbContext;
        }

        public void AddStory(Story story)
        {
            context.Stories.Add(story);
            context.SaveChanges();
        }

        public void AddComment(Comment com, string title)
        {
            context.Stories.First(x => x.Title == title).Subjects.Add(com);
            context.SaveChanges();
        }

        public void AddUser(User use)
        {
            context.Users.Add(use);
            context.SaveChanges();
        }

        public Story Retrieve(string title)
        {
            return context.Stories.First(x => x.Title == title);
        }
    }
}
