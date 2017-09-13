using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MovieRepo;

namespace Service
{
    public class MovieService : IMovieService
    {
        private IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Movie> GetMovies()
        {
           return _repository.Entities.ToList();
        }
    }

    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies();
    }
}
