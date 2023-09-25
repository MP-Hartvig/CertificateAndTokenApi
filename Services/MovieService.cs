using CertificateAndTokenApi.DTO;
using CertificateAndTokenApi.Interfaces;

namespace CertificateAndTokenApi.Services
{
    public class MovieService : IMovieService
    {
        public List<MovieDto> GetMovies()
        {
            return new List<MovieDto> { 
                new MovieDto { 
                    Id = "1", 
                    Title = "The Matrix", 
                    ReleaseDate = "01/01/1999" 
                },
                new MovieDto {
                    Id = "1",
                    Title = "The Shawshank Redemption",
                    ReleaseDate = "02/05/1996"
                },
                new MovieDto {
                    Id = "1",
                    Title = "The Green Mile",
                    ReleaseDate = "08/06/1994"
                },
                new MovieDto {
                    Id = "1",
                    Title = "Die Hard",
                    ReleaseDate = "29/11/1986"
                },
                new MovieDto {
                    Id = "1",
                    Title = "Iron Man",
                    ReleaseDate = "15/03/2004"
                },
            };
        }
    }
}
