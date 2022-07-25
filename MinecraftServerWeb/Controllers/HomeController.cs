﻿using Microsoft.AspNetCore.Mvc;
using MinecraftServerWeb.Models;
using System.Diagnostics;
using MinecraftServerWeb.Repository.Interfaces;
using MinecraftServerWeb.ViewModels;

namespace MinecraftServerWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IndexViewModel viewModel = new();
            var posts =  _unitOfWork.Post.GetWhere(e => e.PostType == PostTypes.Announcement);
            posts = posts.OrderByDescending(e => e.DateCreated);
            viewModel.Posts = posts; 
            viewModel.Users = _unitOfWork.User.GetAll();
            return View(viewModel);
        }

        public IActionResult Rules()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}