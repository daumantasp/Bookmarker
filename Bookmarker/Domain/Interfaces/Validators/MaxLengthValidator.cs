using Bookmarker.Domain.Interfaces.Validation;

namespace Bookmarker.Domain.Interfaces.Validators
{
    internal class MaxLengthValidator : IValidator<string>
    {
        private readonly int _maxLength;
        public MaxLengthValidator(int maxLength)
        {
            if (maxLength < 0)
                throw new ArgumentOutOfRangeException(nameof(maxLength), "Maximum length cannot be negative.");

            _maxLength = maxLength;
        }
        public bool Validate(string input) => input.Length <= _maxLength;
    }
}
