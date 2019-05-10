using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
