using CRUD_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using CRUD_DAL.Repository;
using static CRUD_DAL.Models.Persons;
//using Microsoft.Practices.Unity;
using Unity.Injection;

namespace CRUD_DAL.Unity
{
    public class UnityConfig
    {
       /* public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IRepository<Person>, RepositoryPerson>(new InjectionConstructor(new object[] {"Person"}));
            
        }*/
    }
}
