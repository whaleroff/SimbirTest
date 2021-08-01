using System;
using System.Collections.Generic;
using System.Linq;
using Books.Models;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private static List<Person> _persons = new()
        {
            new Person{id = Guid.NewGuid(), name = "Никита", surname = "Исаев", patronymic = "Сергеевич", dateBithday = "25.05.1995"},
            new Person{id = Guid.NewGuid(), name = "Виктор", surname = "Иванов", patronymic = "Дмитриевич", dateBithday = "12.02.2000"},
            new Person{id = Guid.NewGuid(), name = "Никита", surname = "Маликов", patronymic = "Артемович", dateBithday = "26.04.1993"},
            new Person{id = Guid.NewGuid(), name = "Сергей", surname = "Миронов", patronymic = "Иванович", dateBithday = "18.07.2001"},
            new Person{id = Guid.NewGuid(), name = "Виталий", surname = "Иванов", patronymic = "Кириллович", dateBithday = "12.12.2000"},
        };
        // GET
        [HttpGet]
        public List<Person> Get()
        {
            return _persons;
        }

        [HttpGet("{name}")]
        public List<Person> Get(string name)
        {
            List<Person> foundPersons = _persons.FindAll(item => item.name==name);
            return foundPersons;
        }
        [HttpPost]
        public void Post([FromBody]Person value)
        {
            _persons.Add(value);
        }

        [HttpDelete("{name}")]
        public ActionResult Delete(string name, string surname, string patronymic)
        {
            Guid passId = default;
            List<Person> foundPersons = _persons.FindAll(item => item.name==name && item.surname == surname && item.patronymic == patronymic);
            foreach (var person in foundPersons)
            {
                passId = person.id;
            }
            _persons.Remove(_persons.Single(item=>item.id==passId));
            return Ok();
        }
    }
}