using MyStorage.Models;
using MyStorage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyStorage.Controllers
{
    public class ProductController : Controller
    {
        IRepository<Product> productRepository;

        public ProductController(IRepository<Product> repository)
        {
            productRepository = repository;
        }
        
        // GET: Product
        public ActionResult Index(int id)
        {
            var product = productRepository.Get(id);

            return View(product);
        }

        public ActionResult New()
        {
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = productRepository.Get(id);

            return View("Index", product);
        }

        [HttpPost]
        public ActionResult Save(Product product)
        {
            if (product.Id == 0)
            {
                productRepository.Add(product);
            }
            else
            {
                productRepository.Update(product);
            }

            return RedirectToAction("Index","Home");
        }
    }
}