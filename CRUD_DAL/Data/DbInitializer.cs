using CRUD_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRUD_DAL;
using static CRUD_DAL.Models.Persons;

namespace CRUD_DAL.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.Persons.Any())
            {
                return;   // DB has been seeded
            }

            var users = new Person[]
            {
            new Person{UserName="Roman",UserPassword="Test1",UserEmail="Roman@gmail.com"},
            new Person{UserName="Pavlo",UserPassword="Test2",UserEmail="Pavlo@gmail.com"},
            new Person{UserName="Semen",UserPassword="Test3",UserEmail="Semen@gmail.com"},
            new Person{UserName="Petro",UserPassword="Test4",UserEmail="Petro@gmail.com"},


            };
            foreach (Person s in users)
            {
                context.Persons.Add(s);
            }
            context.SaveChanges();
        }
    }
}
