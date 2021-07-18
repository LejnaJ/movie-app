using TestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movies>> Get();
        IEnumerable<Cast> GetCast(int movieId);
        IEnumerable<Movies> Search(bool isMovie, int page, string searchValue);
    }
}
