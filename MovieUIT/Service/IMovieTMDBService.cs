using MovieUIT.Model;

namespace MovieUIT.Service
{
    public interface IMovieTMDBService
    {
        List<MovieTMDB> Get();
        MovieTMDB Get(string _id);
        MovieTMDB Create(MovieTMDB movieTMDB);
        void Update(string _id, MovieTMDB movieTMDB);
        void Remove(string _id);
    }
}
