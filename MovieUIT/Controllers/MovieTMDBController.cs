using Microsoft.AspNetCore.Mvc;
using MovieUIT.Model;
using MovieUIT.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieUIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieTMDBController : ControllerBase
    {
        private readonly IMovieTMDBService movieTMDBService;

        public MovieTMDBController(IMovieTMDBService movieTMDBService) 
        {
            this.movieTMDBService = movieTMDBService;
        }
        // GET: api/<MovieTMDBController>
        [HttpGet]
        public ActionResult<List<MovieTMDB>> Get()
        {
            return movieTMDBService.Get();
        }

        // GET api/<MovieTMDBController>/5
        [HttpGet("{_id}")]
        public ActionResult<MovieTMDB> Get(string _id)
        {
            //return movieTMDBService.Get(_id);

            var movieTMDB = movieTMDBService.GetById(_id);
            if (movieTMDB == null)
            {
                return NotFound($"Movie with Id = {_id} not found");
            }
            return movieTMDB;
        }

        // GET api/<MovieTMDBController>/5
        // GET api/<MovieTMDBController>/5
        [HttpGet("tmdb/{id}")]
        public ActionResult<MovieTMDB> Get(int id)
        {
            //return movieTMDBService.Get(_id);

            var movieTMDB = movieTMDBService.GetByIdMovie(id);
            if (movieTMDB == null)
            {
                return NotFound($"Movie with Id = {id} not found");
            }
            return movieTMDB;
        }

        // POST api/<MovieTMDBController>
        [HttpPost]
        public ActionResult Post([FromBody] MovieTMDB movieTMDB)
        {
            movieTMDBService.Create(movieTMDB);
            return CreatedAtAction(nameof(Get),new {_id = movieTMDB._id} ,movieTMDB);
        }

        // PUT api/<MovieTMDBController>/5
        [HttpPut("{id}")]
        public ActionResult<MovieTMDB> Put(string id, [FromBody] MovieTMDB movieTMDB)
        {
            var existingMovieTMDB = movieTMDBService.GetById(id);
            if (existingMovieTMDB == null)
            {
                return NotFound($"MovieTMDB with id = {id} not found");
            }
            movieTMDBService.Update(id, movieTMDB);
            return NoContent();
        }

        // DELETE api/<MovieTMDBController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var movieTMDB = movieTMDBService.GetById(id);
            if(movieTMDB == null)
            {
                return NotFound($"MovieTMDB with id = {id} not found");
            }
            movieTMDBService.Remove(id);
            return Ok();
        }
    }
}
