using System;

namespace MarvelSeer.Domain.AggregatesModel.MovieAggregate
{
    public struct Overview
    {
        private readonly string _value;

        private Overview(string value) { _value = value; }

        public static Overview Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Resumo inválido! Deve ser fornecido um resumo do filme.", nameof(value));

            return new Overview(value);
        }

        public override string ToString() => _value;

        /// <summary>
        /// Como utilizar:
        /// Overview ov = "Filme sobre o primeiro vingador: Capitão América!";
        /// </summary>
        public static implicit operator Overview(string input) => Create(input);

        public static implicit operator string(Overview input) => input._value;
    }
}