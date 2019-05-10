using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Genre_ID { get; set; }
        public Genre Genre { get; set; }
    }
}
