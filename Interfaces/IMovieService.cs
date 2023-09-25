using CertificateAndTokenApi.DTO;

namespace CertificateAndTokenApi.Interfaces
{
    public interface IMovieService
    {
        public List<MovieDto> GetMovies(); 
    }
}
