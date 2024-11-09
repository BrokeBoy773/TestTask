using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace Domain.ValueObjects
{
    public class BookTitle : ValueObject
    {
        private static readonly string WhiteSpacesPattern = @"\s+";
        private static readonly string TitlePattern = @"^[a-zA-Zа-яА-ЯЁё0-9 -.,!?:%№()]+$";
        private static readonly string TitleInvalidValue = @"^[-.!?:%№()]+$";

        public string Title { get; }

        private BookTitle(
            string title)
        {
            Title = title;
        }

        public static Result<BookTitle> Create(
            string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Result.Failure<BookTitle>("title is null or white space");

            string updatedTitle = Regex
                .Replace(title, WhiteSpacesPattern, match => " ")
                .Trim();

            if (updatedTitle.Length > 128)
                return Result.Failure<BookTitle>("title exceeds maximum string length");

            if (!Regex.IsMatch(updatedTitle, TitlePattern) ||
                Regex.IsMatch(updatedTitle, TitleInvalidValue))
                return Result.Failure<BookTitle>("title contains invalid characters");

            BookTitle validBookTitle = new(updatedTitle);

            return Result.Success(validBookTitle);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Title;
        }
    }
}
