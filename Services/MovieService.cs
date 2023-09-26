using CertificateAndTokenApi.DTO;
using CertificateAndTokenApi.Interfaces;

namespace CertificateAndTokenApi.Services
{
    public class MovieService : IMovieService
    {
        static List<MovieDto> movies = new List<MovieDto>();
        static int id = 6;

        public List<MovieDto> GetMovies()
        {
            if (movies.Count == 0)
            {
                movies.Add(new MovieDto
                {
                    Id = "1",
                    Title = "The Matrix",
                    ReleaseDate = "01/01/1999"
                });
                movies.Add(new MovieDto
                {
                    Id = "2",
                    Title = "The Shawshank Redemption",
                    ReleaseDate = "02/05/1996"
                });
                movies.Add(new MovieDto
                {
                    Id = "3",
                    Title = "The Green Mile",
                    ReleaseDate = "08/06/1994"
                });
                movies.Add(new MovieDto
                {
                    Id = "4",
                    Title = "Die Hard",
                    ReleaseDate = "11/29/1986"
                });
                movies.Add(new MovieDto
                {
                    Id = "5",
                    Title = "Iron Man",
                    ReleaseDate = "03/15/2004"
                });
            }

            return movies;
        }

        public List<MovieDto> CreateMovie(MovieDto movie)
        {
            movie.Id = id.ToString();
            movies.Add(movie);
            id++;
            return movies;
        }

        public List<MovieDto> UpdateMovie(MovieDto movie)
        {
            int idx = movies.IndexOf(movies.Where(x => x.Id == movie.Id).SingleOrDefault(movie));
            movies[idx] = movie;
            return movies;
        }

        public List<MovieDto> DeleteMovie(string id)
        {
            movies.Remove(movies.Where(x => x.Id == id).SingleOrDefault() ?? new MovieDto());
            return movies;
        }
    }
}
