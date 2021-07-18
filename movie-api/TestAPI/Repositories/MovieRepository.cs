using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {

        private readonly MovieContext _context;

        //Search and rating should go here
        public MovieRepository(MovieContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Movies>> Get()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Cast> GetCast(int movieId)
        {
            return _context.Cast.Where(x => x.MovieId == movieId).Include(x => x.ActorId);
        }

        //filter by category with bool


        //we also need a page inital value set on 1 and pageSize 10 for pagination
        //add searchValue and see if it contains a keyword followed by a number (of stars, years) -
        //TODO which reminds me to add ratings in db ----  and actors!

        public IEnumerable<Movies> Search(bool isMovie = true, int page = 1, string searchValue = "")
        {
          
            int pageSize = 10;
            int currentYear = DateTime.Today.Year;
            int customYear = 0;
            int starsNr = 0;
            string inputStars = "";

            //Reset searchValue when it's null, for example when we delete input text 
            if (searchValue == null)
            {
                searchValue = "";
            }

            //Search with custom keywords and dates

            if (searchValue.ToLower().Contains("after") && searchValue.Any(char.IsDigit))
            {

                //find digits in string and convert them to integers
                string InputYear = new string(searchValue.Where(char.IsDigit).ToArray());
                var FormattedYear = int.TryParse(InputYear, out customYear);

                if (FormattedYear)
                {

                    return _context.Movies.Where(x => x.isMovie == isMovie && (x.ReleaseDate.Year > customYear || x.MovieName.Contains(searchValue) || x.MovieDescription.Contains(searchValue)))
                     .OrderByDescending(x => x.AverageRating)
                     //Pagination here
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                }
            }

            if (searchValue.ToLower().Contains("before") && searchValue.Any(char.IsDigit))
            {

                string InputYear = new string(searchValue.Where(char.IsDigit).ToArray());
                var FormattedYear = int.TryParse(InputYear, out customYear);

                if (FormattedYear)
                {

                    return _context.Movies.Where(x => x.isMovie == isMovie && (x.ReleaseDate.Year < customYear || x.MovieName.Contains(searchValue) || x.MovieDescription.Contains(searchValue)))
                        .OrderByDescending(x => x.AverageRating)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
                }
            }

            if (searchValue.ToLower().Contains("older than") && searchValue.ToLower().Contains("years") && searchValue.Any(char.IsDigit))
            {
                    string InputYear = new string(searchValue.Where(char.IsDigit).ToArray());
                    var FormattedYear = int.TryParse(InputYear, out customYear);

                    if (FormattedYear)
                    {
                        return _context.Movies.Where(x => x.isMovie == isMovie && ((currentYear - x.ReleaseDate.Year) > customYear || x.MovieName.Contains(searchValue) || x.MovieDescription.Contains(searchValue)))
                                     .OrderByDescending(x => x.AverageRating)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);

                }
                
              
            }


            //Stars
            if (searchValue.ToLower().Contains("stars")) {
             
               //for example, 5 stars
                inputStars = new string(searchValue.Where(char.IsDigit).ToArray());
                var FormattedStars = int.TryParse(inputStars, out starsNr);

                if (FormattedStars)
                {
                    return _context.Movies.Where(x => x.isMovie == isMovie && x.AverageRating >= starsNr || x.MovieName.Contains(searchValue) || x.MovieDescription.Contains(searchValue))
                                .OrderByDescending(x => x.AverageRating)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize);
                }

                //Since we already have statement for 'stars' let's see if we have some other keywords as well: 
                if (searchValue.ToLower().Contains("at least"))
                {
                    FormattedStars = false;
                    inputStars = new string(searchValue.Where(char.IsDigit).ToArray());
                    FormattedStars = int.TryParse(inputStars, out starsNr);

                    if (FormattedStars)
                    {
                        return _context.Movies.Where(x => x.isMovie == isMovie && x.AverageRating >= starsNr || x.MovieName.Contains(searchValue) || x.MovieDescription.Contains(searchValue))
                                    .OrderByDescending(x => x.AverageRating)
                                    .Skip((page - 1) * pageSize)
                                    .Take(pageSize);
                    }
      
                }
            }

            //if none applies
            return _context.Movies.Where(x => x.isMovie == isMovie && (x.MovieName.Contains(searchValue)  || x.MovieDescription.Contains(searchValue)|| searchValue == ""))
                        .OrderByDescending(x => x.AverageRating)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
        }

       
       

    // TODO Update ratings 
}
}
