using CRUD_DAL.Data;
using CRUD_DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_DAL.Repository
{
    public class GenericRepository<T>: IRepository<T> where T: class
    {
        private ApplicationDbContext _dbContext;
        private DbSet<T> table;
        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
            table = _dbContext.Set<T>();
        }
        public void Create(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(Object Id)
        {
            T exists = table.Find(Id);
            table.Remove(exists);
        }
        public List<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(Object Id)
        {
            return table.Find(Id);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
