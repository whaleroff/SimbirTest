using System;

namespace Books.Models
{
    public class Person
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public string dateBithday { get; set; }
    }
}