using MongoDB.Driver;
using MovieUIT.Model;

namespace MovieUIT.Service
{
    public class MovieTMDBService : IMovieTMDBService
    {
        private readonly IMongoCollection<MovieTMDB> _movieTMDB;

        public MovieTMDBService(IMovieUITSettings settings, IMongoClient mongoClient) 
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _movieTMDB = database.GetCollection<MovieTMDB>(settings.MovieTMDBCollection);
        }
        public MovieTMDB Create(MovieTMDB movieTMDB)
        {
            
            _movieTMDB.InsertOne(movieTMDB);
            return movieTMDB;
        }

        public List<MovieTMDB> Get()
        {
            return _movieTMDB.Find(movieTMDB => true).ToList();
        }

        public MovieTMDB Get(string _id)
        {
            return _movieTMDB.Find(movie => movie._id == _id).FirstOrDefault();
        }


        public void Remove(string _id)
        {
            _movieTMDB.DeleteOne(movie => movie._id == _id);
        }

        public void Update(string id, MovieTMDB movieTMDB)
        {
            _movieTMDB.ReplaceOne(movie => movie._id == id, movieTMDB);
        }
    }
}
