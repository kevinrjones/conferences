using Entities;
using Repository;

namespace MovieRepo
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository()
        {
            _database.Add(new Movie { Id = 1, Director = "QT", MovieTitle = "Pulp Fictions" });
            _database.Add(new Movie { Id = 2, Director = "Billy Wilder", MovieTitle = "Some Like It Hot" });
        }
    
    }
}