using Bookmarker.Domain.Interfaces.Validation;

namespace Bookmarker.Domain.Interfaces.Validators
{
    internal class MinLengthValidator : IValidator<string>
    {
        private readonly int _minLength;
        public MinLengthValidator(int minLength)
        {
            if (minLength < 0)
                throw new ArgumentOutOfRangeException(nameof(minLength), "Minimum length cannot be negative.");

            _minLength = minLength;
        }
        public bool Validate(string input) => input.Length >= _minLength;
    }
}
