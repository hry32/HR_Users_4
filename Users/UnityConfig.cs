using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity;
using CRUD_DAL.Interface;
using CRUD_DAL.Repository;
using static CRUD_DAL.Models.Persons;
using Users.Controllers;

namespace Users
{
    internal static class UnityConfig
    {
        
        public static UnityContainer Register()
        {
            var container = new UnityContainer();
            container.RegisterType<IRepository<Person>, RepositoryPerson>();
            container.RegisterType<PersonDetailsController>();
            return container;
           // DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
