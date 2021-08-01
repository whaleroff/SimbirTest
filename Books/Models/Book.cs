using System;

namespace Books.Models
{
    public class Book
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
    }
}