using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DAL.Interface
{
    public interface IRepository<T> where T: class
    {
         List<T> GetAll();
        T GetById(Object Id);
        void Create(T _object);
        void Update(T _object);
        void Delete(Object Id);
        void Save();

    }
}
