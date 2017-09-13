using Entities;
using Repository;

namespace MovieRepo
{
    public interface IMovieRepository : IRepository<Movie>
    {
    }
}