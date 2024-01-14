using MovieUIT.Model;

namespace MovieUIT.Service
{
    public interface IMovieTMDBService
    {
        List<MovieTMDB> Get(int index);
        MovieTMDB GetById(string _id);
        MovieTMDB GetByIdMovie(int id);
        MovieTMDB Create(MovieTMDB movieTMDB);
        void Update(string _id, MovieTMDB movieTMDB);
        void Remove(string _id);
    }
}
