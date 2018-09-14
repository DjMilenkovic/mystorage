using MyStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyStorage.Repository
{
    public class SqlDbProductRespository : IRepository<Product>
    {
        ApplicationDbContext dbContext;

        public SqlDbProductRespository()
        {
            dbContext = new ApplicationDbContext();
        }

        public void Add(Product item)
        {
            dbContext.Products.Add(item);
            dbContext.SaveChanges();
        }

        public Product Get(int id)
        {
            return GetProducts().SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
           return dbContext.Products.ToList();
        }

        public void Update(Product item)
        {
            var product = dbContext.Products.SingleOrDefault(p => p.Id == item.Id);
            if (product != null)
            {
                product.Name = item.Name;
                product.Description = item.Description;
                product.Category = item.Category;
                product.Manufacturer = item.Manufacturer;
                product.Supplier = item.Supplier;
                product.Price = item.Price;

                dbContext.SaveChanges();
            }
        }
    }
}