using CertificateAndTokenApi.DTO;

namespace CertificateAndTokenApi.Interfaces
{
    public interface IMovieService
    {
        public List<MovieDto> GetMovies();
        public List<MovieDto> CreateMovie(MovieDto movie);
        public List<MovieDto> UpdateMovie(MovieDto movie);
        public List<MovieDto> DeleteMovie(string id);
    }
}
