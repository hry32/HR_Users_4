using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DAL.Interface
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();

        public T GetById(int Id);
        public Task<T> Create(T _object);
        //public Task<T> Create(string username, string userpassword, string useremail);
        public void Update(T _object);

        public void Delete(T _object);
        
    }
}
