using CRUD_DAL.Data;
using CRUD_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CRUD_DAL.Models.Persons;

namespace CRUD_BAL.Service
{
    public class PersonService
    {
        /* private readonly IRepository<Person> _person;

         public PersonService(IRepository<Person> perosn)
         {
             _person = perosn;
         }
         //Get Person Details By Person Id  
         public IEnumerable<Person> GetPersonByUserId(int Id)
         {
             return _person.GetAll().Where(x => x.Id == Id).ToList();
         }
         //GET All Person Details   
         public IEnumerable<Person> GetAllPersons()
         {
             try
             {
                 return _person.GetAll().ToList();
             }
             catch (Exception)
             {
                 throw;
             }
         }
         //Get Person by Person Name  
         public Person GetPersonByUserName(string username)
         {
             return _person.GetAll().Where(x => x.UserName == username).FirstOrDefault();
         }
         //Add Person  
        /* public async Task<Person> AddPerson(Person Person)
         {
             return await _person.Create(Person);
         }
         //Delete Person   
         public bool DeletePerson(int id)
         {
             try
             {
                 var DataList = _person.GetAll().Where(x => x.Id == id).ToList();
                 foreach (var item in DataList)
                 {
                     _person.Delete(item);
                 }
                 return true;
             }
             catch (Exception)
             {
                 return false;
             }

         }
         //Update Person
         public bool UpdatePerson(int id, Person person)
         {

               try
             {
               //var DataList = _person.GetAll().Where(x => x.Id == id).ToList();
              // foreach (var item in DataList)
              // {
                     _person.Update(person);
                // }
               return true;
             }
            catch (Exception)
           {
               return false;
           }
         }*/
    }
}
