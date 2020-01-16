﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkeletonSite.Models;
using SkeletonSite.Repositories;

namespace SkeletonSite.Controllers
{
    public class HomeController : Controller
    {
        IRepository repo;

        public HomeController(IRepository r)
        {
            repo = r;
        }

        public ViewResult Index()
        {   
            ViewData["Title"] = "Home";
            return View();
        }

        public ViewResult History()
        {
            ViewData["Title"] = "History";
            return View();
        }

        [HttpGet]
        public ViewResult StoryPost()
        {
            ViewData["Title"] = "StoryPost";
            return View();
        }

        [HttpPost]
        public ViewResult StoryPost(Story post)
        {
            ViewData["Title"] = "StoryPost";
            if (ModelState.IsValid)
            {
                repo.AddStory(post);
                return View();
            }
            else
            {
                return View();
            }
        }
        
        public ViewResult Sources()
        {
            ViewData["Title"] = "Sources";
            return View();
        }

        public ViewResult StoryBoard()
        {
            ViewData["Title"] = "StoryBoard";
            for (int i = 0; i < repo.Stories.Count; i++)
            {
                if (repo.Stories[i].Title != null)
                    repo.Stories.Sort((title1, title2) => title1.Title.CompareTo(title2.Title));
            }
            return View(repo.Stories);
        }

        [HttpGet]
        public IActionResult Comment(string storyTitle)
        {
            ViewData["Title"] = "Comment";
            ViewBag.Story = storyTitle;
            return View("Comment");
        }

        [HttpPost]
        public IActionResult Comment(Comment com, string storyTitle)
        {
            ViewData["Title"] = "Comment";
            if (ModelState.IsValid)
            {
                repo.AddComment(com, storyTitle);
                return RedirectToAction("StoryBoard");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult UserCreate()
        {
            ViewData["Title"] = "UserCreate";
            return View("UserCreate");
        }

        [HttpPost]
        public IActionResult UserCreate(User use)
        {
            ViewData["Title"] = "UserCreate";
            if (ModelState.IsValid)
            {
                repo.AddUser(use);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ViewResult Books()
        {
            return View(BookCollection.Library);
        }

        public ViewResult Links()
        {
            return View(LinkCollection.Bank);
        }

        /* Lab 6
         * public ContentResult ContentMethod()
        {
            return Content("apples");
        }

        public NotFoundResult NotFoundMethod()
        {
            return NotFound();
        }

        public UnauthorizedResult UnauthMethod()
        {
            return Unauthorized();
        }*/
    }
}
