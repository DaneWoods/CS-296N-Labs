using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkeletonSite.Models;

namespace SkeletonSite.Repositories
{
    public interface IRepository
    {
        List<Story> Stories{ get; }
        void AddStory(Story story);
        void AddComment(Comment com, string title);
        void AddUser(User use);
        Story Retrieve(string title);
    }
}
