using System;

namespace MarvelSeer.Domain.AggregatesModel.MovieAggregate
{
    public record Title
    {
        public string Name { get; init; }
        public string Poster { get; init; }

        private Title() { }

        public static Title Create(string name, string poster)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Título inválido! Deve ser fornecido um título para o filme.", nameof(name));

            if (string.IsNullOrWhiteSpace(poster))
                throw new ArgumentException("Cartaz inválido! Deve ser fornecido um cartaz para o filme.", nameof(poster));

            return new Title { Name = name, Poster = poster };
        }
    }
}