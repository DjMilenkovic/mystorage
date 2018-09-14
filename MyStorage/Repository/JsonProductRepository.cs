using MyStorage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MyStorage.Repository
{
    public class JsonProductRepository : IRepository<Product>
    {
        string filePath;

        public JsonProductRepository()
        {
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            filePath = folderPath + @"\App_Data\jsonDB.json";
        }

        public void Add(Product item)
        {
            var productCollection = GetCollectionFromJSON();

            if (item.Id == 0)
            {
                item.Id = productCollection.Max(p => p.Id) + 1;
                productCollection.Add(item);

                InsertInJSON(productCollection);
            }
        }   

        public Product Get(int id)
        {
            return GetProducts().SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return GetCollectionFromJSON().OrderBy(p => p.Id);
        }

        public void Update(Product product)
        {
            var productCollection = GetCollectionFromJSON();

            var item = productCollection.FirstOrDefault(p => p.Id == product.Id);
            if (item != null)
            {
                productCollection.Remove(item);

                item.Name = product.Name;
                item.Description = product.Description;
                item.Category = product.Category;
                item.Manufacturer = product.Manufacturer;
                item.Supplier = product.Supplier;
                item.Price = product.Price;

                productCollection.Add(item);
            }

            InsertInJSON(productCollection); 
        }

        private ICollection<Product> GetCollectionFromJSON()
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<ICollection<Product>>(json);
            }
        }

        private void InsertInJSON(ICollection<Product> productCollection)
        {
            var convertToJson = JsonConvert.SerializeObject(productCollection, Formatting.Indented);

            using (StreamWriter w = System.IO.File.CreateText(filePath))
            {
                w.Write(convertToJson);
            }
        }
    }
}