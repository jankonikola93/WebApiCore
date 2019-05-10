using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            :base(options)
        {

        }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Movie> Movie { get; set; }
    }
}
