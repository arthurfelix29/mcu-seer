using System;
using System.Globalization;

namespace MarvelSeer.Domain.AggregatesModel.MovieAggregate
{
    public struct Release
    {
        private const string DatePattern = "yyyy-MM-dd";

        public int DaysUntil { get; private set; }
        public DateTime Date { get; private set; }

        private Release(int daysUntil, DateTime date)
        {
            DaysUntil = daysUntil;
            Date = date;
        }

        public static Release Create(int daysUtil, string date)
        {
            if (daysUtil < 0)
                throw new ArgumentException("Quantidade de dias inválida! Deve ser fornecido um valor maior que zero para a quantidade de dias até o lançamento do filme.", nameof(daysUtil));

            if (!IsValidDate(date, out DateTime releaseDate))
                throw new ArgumentException("Data de lançamento inválida! Deve ser fornecida uma data válida para o lançamento do filme.", nameof(date));

            return new Release(daysUtil, releaseDate);
        }

        public override string ToString() => $"{DaysUntil} dia(s) até o lançamento previsto para {Date.ToShortDateString()}";

        public string ToFormattedString(DateTime date)
        {
            return date.ToString(DatePattern);
        }

        private static bool IsValidDate(string value, out DateTime validDate)
        {
            return DateTime.TryParseExact(value, DatePattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out validDate);
        }
    }
}