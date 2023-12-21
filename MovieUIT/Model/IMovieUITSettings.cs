namespace MovieUIT.Model
{
    public interface IMovieUITSettings
    {
        string MovieTMDBCollection { get; set; }
        string MovieOPhimCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
