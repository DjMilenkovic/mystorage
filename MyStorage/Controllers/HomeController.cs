using MyStorage.Models;
using MyStorage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyStorage.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> productRepository;

        public HomeController(IRepository<Product> repository)
        {
            productRepository = repository;
        }
        public ActionResult Index()
        {
            var product = productRepository.GetProducts();

            return View(product);
        }
    }
}