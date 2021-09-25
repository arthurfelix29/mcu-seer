using System;

namespace MarvelSeer.Domain.AggregatesModel.MovieAggregate
{
    public struct MovieType
    {
        private readonly string _value;

        private MovieType(string value) { _value = value; }

        public static MovieType Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Tipo inválido! Deve ser fornecido o tipo do filme.", nameof(value));

            return new MovieType(value);
        }

        public override string ToString() => _value;

        /// <summary>
        /// Como utilizar:
        /// MovieType mt = "Ação e Suspense";
        /// </summary>
        public static implicit operator MovieType(string input) => Create(input);

        public static implicit operator string(MovieType input) => input._value;
    }
}