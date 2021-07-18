using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string MovieDescription { get; set; }
        public bool isMovie { get; set; }
        public string ImgUrl { get; set; }
        public string ImgAlt { get; set; }
        public float AverageRating { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
        public IEnumerable<Cast> Cast { get; set; }

    }
}
