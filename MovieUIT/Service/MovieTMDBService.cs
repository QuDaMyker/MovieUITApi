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

        public MovieTMDB GetById(String id)
        {
            return _movieTMDB.Find(movie => movie._id == id).FirstOrDefault();
        }

        public MovieTMDB GetByIdMovie(int id)
        {
            return _movieTMDB.Find(movie => movie.Id == id).FirstOrDefault();
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


/*
 using MongoDB.Driver;
using MovieUIT.Model;
using System;

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
            try
            {
                _movieTMDB.InsertOne(movieTMDB);
                return movieTMDB;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ tại đây
                throw ex; // hoặc thực hiện xử lý ngoại lệ cụ thể và trả về thông báo hoặc log lỗi
            }
        }

        public List<MovieTMDB> Get()
        {
            try
            {
                return _movieTMDB.Find(movieTMDB => true).ToList();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ tại đây
                throw ex; // hoặc thực hiện xử lý ngoại lệ cụ thể và trả về thông báo hoặc log lỗi
            }
        }

        public MovieTMDB GetById(String id)
        {
            try
            {
                return _movieTMDB.Find(movie => movie._id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ tại đây
                throw ex; // hoặc thực hiện xử lý ngoại lệ cụ thể và trả về thông báo hoặc log lỗi
            }
        }

        // Các phương thức khác có thể được bao bọc trong khối try-catch tương tự
    }
}

 */