using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models;

namespace Demo.BLL.Interfaces
{
    public interface IGenericRepository<T>
    {
        public IEnumerable<T> GetAll();
        T GetById(int id);
        public int Add(T item);
        public int Update(T item);
        public int Delete(T item);
    }
}
