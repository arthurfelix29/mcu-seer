using FluentAssertions;
using MarvelSeer.Domain.AggregatesModel.MovieAggregate;
using Xunit;

namespace MarvelSeer.Domain.Test
{
    public class MovieTest
    {
        [Fact(DisplayName = "CriarFilme")]
        public void Create()
        {
            var titleName = "Homem de Ferro";
            var titlePoster = "homem-ferro.jpg";
            var overview = "Tony Stark cria uma armadura de ferro para combater o terrorismo mundial.";
            var movieType = "Ação";
            var daysUntilRelease = 34;
            var releaseDate = "2008-05-12";

            var movie = Movie.Create(Title.Create(titleName, titlePoster),
                                     Overview.Create(overview),
                                     MovieType.Create(movieType),
                                     Release.Create(daysUntilRelease, releaseDate));

            movie.Id.Should().NotBeEmpty();
            titleName.Should().Be(movie.Title.Name);
            titlePoster.Should().Be(movie.Title.Poster);
            overview.Should().Be(movie.Overview);
            movieType.Should().Be(movie.Type);
            daysUntilRelease.Should().Be(movie.Release.DaysUntil);
            releaseDate.Should().Be(movie.Release.ToFormattedString(movie.Release.Date));
        }
    }
}