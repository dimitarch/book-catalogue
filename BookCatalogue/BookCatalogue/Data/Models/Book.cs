using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogue.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public bool Read { get; set; }
        public bool Liked { get; set; }
        public bool Loved { get; set; }
        public string Comment { get; set; }

        public Book() : this(null, null)
        {

        }

        public Book(string name, string author)
        {
            this.Name = name;
            this.Author = author;
        }
    }
}