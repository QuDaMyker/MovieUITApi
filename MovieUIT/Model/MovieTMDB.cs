using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieUIT.Model
{
    public class MovieTMDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; } = String.Empty;
        [BsonElement("adult")]
        public bool Adult { get; set; }
        [BsonElement("backdrop_path")]
        public string Backdrop_path { get; set; }
        [BsonElement("genre_ids")]
        public List<int> Genre_ids { get; set; }
        [BsonElement("id")]
        public Int32 Id { get; set; }
        [BsonElement("original_language")]
        public string Original_language { get; set; }
        [BsonElement("original_title")]
        public String Original_title { get; set; }
        [BsonElement("overview")]
        public string Overview { get; set; }
        [BsonElement("popularity")]
        public dynamic Popularity { get; set; }
        [BsonElement("poster_path")]
        public string Poster_path { get; set; }
        [BsonElement("release_date")]
        public string Release_date { get; set; }
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("video")]
        public bool Video { get; set; }
        [BsonElement("vote_average")]
        public dynamic Vote_average { get; set; }
        [BsonElement("vote_count")]
        public dynamic vote_count { get; set; }
    }
}
