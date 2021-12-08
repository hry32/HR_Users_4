using System;
using System.Collections.Generic;
using System.Text;
using static CRUD_DAL.Models.Persons;

namespace CRUD_DAL.Interface
{
    public interface IApplicationDbContex: IDisposable
    
    {
   // IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
    
    
}
