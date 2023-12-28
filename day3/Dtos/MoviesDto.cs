using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlysProject.Models;

namespace VidlysProject.Dtos
{
    public class MoviesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public MovieGenreDto Genre { get; set; }


        public DateTime ReleaseDate { get; set; }
        public DateTime DataAdded { get; set; }
        public int NumberInStock { get; set; }
    }
}