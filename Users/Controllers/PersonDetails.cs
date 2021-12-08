using CRUD_BAL.Service;
using CRUD_DAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using static CRUD_DAL.Models.Persons;
using Unity;

namespace Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDetailsController : ControllerBase
    {
        //private readonly PersonService _personService;
        private readonly IRepository<Person> _personService;
        /*public PersonDetailsController(PersonService ProductService)
        {
            _personService = ProductService;
        }*/

        public PersonDetailsController(IUnityContainer container)
        {
            //_personService = container.Resolve<PersonService>();
            _personService = container.Resolve<IRepository<Person>>();
        }
        /**********************************************/

        //GET All Person  
        [HttpGet]
        public Object GetAllPersons()
        {
            var data = _personService.GetAll();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpPost]
        //[Route("Add")]
        public Object AddPerson([FromBody] Person person)
        {
            try
            {
                _personService.Create(person);
                _personService.Save();
                return GetAllPersons();
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpDelete("{id}")]
        public bool DeletePerson(int id)
        {
            try
            {
                _personService.Delete(id);
                _personService.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Update Person  
        [HttpPut("{id}")]
        public bool UpdatePerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return false;
            }
            _personService.Update(person);
            _personService.Save();
            return true;
        }
        //GET All Person by Name  
        [HttpGet("{Id}")]
        public Object GetAllPersonByName(int Id)
        {
            var data = _personService.GetById(Id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }



        /**********************************************/

        /* [HttpPost]
         //[Route("Add")]
         public async Task<Object> AddPerson([FromBody] Person person)         
         {

             try
             {       
                     var data = await _personService.AddPerson(person);
                 var json = JsonConvert.SerializeObject(person, Formatting.Indented,
                     new JsonSerializerSettings()
                     {
                         ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                     }
                 );
                 return "New person has been added successfully";
             }
             catch (Exception)
             {
                 return false;
             }            
         }

         [HttpDelete("{id}")]
         public bool DeletePerson(int id)
         {
             try
             {
                 _personService.DeletePerson(id);
                 return true;
             }
             catch (Exception)
             {
                 return false;
             }
         }
         //Update Person  
         [HttpPut("{id}")]
         public bool UpdatePerson(int id, Person person)
         {
             if (id != person.Id)
             {
                 return false;
             }
             _personService.UpdatePerson(id, person);
             return true;            
         }
         //GET All Person by Name  
         [HttpGet("{Username}")]
         public Object GetAllPersonByName(string Username)
         {
             var data = _personService.GetPersonByUserName(Username);
             var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                 new JsonSerializerSettings()
                 {
                     ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                 }
             );
             return json;
         }

         //GET All Person  
         [HttpGet]
         public Object GetAllPersons()
         {
             var data = _personService.GetAllPersons();
             var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                 new JsonSerializerSettings()
                 {
                     ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                 }
             );
             return json;
         }*/

    }
}
