using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SkeletonSite.Models;
using SkeletonSite.Controllers;
using SkeletonSite.Repositories;

namespace SkeletonSite.Tests
{
    public class HomeControllerTests 
    {
        [Fact]
        public void StoryBankSortTest()
        {
            // Arrange
            var repo = new FakeStoriesRepository();
            var homeController = new HomeController(repo);
            repo.AddInitialStories();
            // Act
            homeController.StoryBoard();
            // Assert
            Assert.Equal("King of Grapes", repo.Stories[repo.Stories.Count - 1].Title);
        }

        [Fact]
        public void AddStoryTest()
        {
            // Arrange
            var repo = new FakeStoriesRepository();
            var homeController = new HomeController(repo);
            Story sortedStory = new Story();
            sortedStory.Title = "King of Apples";
            sortedStory.Text = "Lots of apples";
            // Act
            homeController.StoryPost(sortedStory);
            // Assert
            Assert.Equal(sortedStory, repo.Stories[repo.Stories.Count - 1]);
        }

        [Fact]
        public void RetrieveStoryTest()
        {
            // Arrange
            var repo = new FakeStoriesRepository();
            var homeController = new HomeController(repo);
            Story sortedStory = new Story();
            repo.AddInitialStories();
            // Act
            sortedStory = repo.Retrieve(repo.Stories[0].Title);
            // Assert
            Assert.Equal("King of Apples", sortedStory.Title);
        }

        [Fact]
        public void AddCommentTest()
        {
            // Arrange
            var repo = new FakeStoriesRepository();
            var homeController = new HomeController(repo);
            string com = "Great story.";
            string title = "King of Grapes";
            repo.AddInitialStories();
            Story tstory = repo.Retrieve(title);
            Comment tcom = new Comment();
            tcom.Text = com;
            // Act
            homeController.Comment(com, title);
            // Assert
            Assert.Equal(1, repo.Retrieve(title).Subjects.Count);
            Assert.Equal(tcom.Text, tstory.Subjects[0].Text);
        }
    }
}
