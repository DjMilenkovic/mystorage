using MyStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStorage.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetProducts();
        T Get(int id);
        void Add(T item);
        void Update(T item);
    }
}
