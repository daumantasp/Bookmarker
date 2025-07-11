using Bookmarker.Domain.Interfaces.Validation;
using System.Text.RegularExpressions;

namespace Bookmarker.Domain.Interfaces.Validators
{
    internal class UrlValidator : IValidator<string>
    {
        public bool Validate(string input)
        {
            string pattern = @"^(https?://)?([\w\-]+\.)+[\w\-]+(/[\w\-./?%&=]*)?$";
            return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }
    }
}
