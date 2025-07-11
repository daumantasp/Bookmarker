using Bookmarker.Domain.Interfaces.Validation;
using System.Globalization;

namespace Bookmarker.Domain.Interfaces.Validators
{
    internal class DateValidator : IValidator<string>
    {
        public bool Validate(string input)
        {
            return DateTime.TryParseExact(
                input,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime _);
        }
    }
}
