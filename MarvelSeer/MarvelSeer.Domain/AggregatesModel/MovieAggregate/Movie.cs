using MarvelSeer.Domain.Core.Interfaces;
using MarvelSeer.Domain.Core.Models;

namespace MarvelSeer.Domain.AggregatesModel.MovieAggregate
{
    public class Movie : Entity, IAggregateRoot
    {
        public Title Title { get; private set; }
        public Overview Overview { get; private set; }
        public MovieType Type { get; private set; }
        public Release Release { get; private set; }

        private Movie() { }

        public static Movie Create(Title title, Overview overview, MovieType type, Release release)
        {
            return new Movie
            {
                Title = title,
                Overview = overview,
                Type = type,
                Release = release
            };
        }
    }
}