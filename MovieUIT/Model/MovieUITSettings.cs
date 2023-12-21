namespace MovieUIT.Model
{
    public class MovieUITSettings : IMovieUITSettings
    {
        public string MovieTMDBCollection { get ; set ; } = String.Empty;
        public string MovieOPhimCollection { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
