using CRUD_BAL.Service;
using CRUD_DAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CRUD_DAL.Models.Persons;
using CRUD_DAL.Unity;
using Unity;

namespace Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDetailsController : ControllerBase
    {
        //UnityConfig unity = new UnityConfig();
        private readonly PersonService _personService;
       
        /*public PersonDetailsController(PersonService ProductService)
        {
            _personService = ProductService;
        }*/

        public PersonDetailsController(IUnityContainer container)
        {
            _personService = container.Resolve<PersonService>();
        }

        [HttpPost]
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
        }
    }
}
