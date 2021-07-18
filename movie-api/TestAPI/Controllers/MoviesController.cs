
using TestAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepo = movieRepository;

        }

        [HttpGet("search/{isMovie?}")]
        public IActionResult Search(bool isMovie = true, int page = 1, string searchValue = "")
        {
            var model = new List<Movies>();


            var movies = _movieRepo.Search(isMovie,  page, searchValue);


            model = movies.Select(x => new Movies
            {
                MovieId = x.MovieId,
                MovieName = x.MovieName,
                ImgUrl = x.ImgUrl,
                ImgAlt = x.ImgAlt,
                MovieDescription = x.MovieDescription,
                //Actors = _movieRepo.GetCast(x.MovieId).Select(a => new Actor
                //{
                //    //Id = a.ActorId,

                //}).ToList(),
                ReleaseDate = x.ReleaseDate,
                AverageRating = x.AverageRating,
                isMovie = x.isMovie,

            }).ToList();


            return Ok(model);

        }

    }
}
