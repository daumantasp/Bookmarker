using Bookmarker.Domain.Interfaces.Validation;

namespace Bookmarker.Domain.Interfaces.Validators
{
    internal class WordsCountValidator : IValidator<string>
    {
        private readonly int _wordsCount;
        public WordsCountValidator(int wordsCount)
        {
            if (wordsCount < 0)
                throw new ArgumentOutOfRangeException(nameof(wordsCount), "Words count cannot be negative.");

            _wordsCount = wordsCount;
        }
        public bool Validate(string input)
        {
            var words = input.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length == _wordsCount;
        }
    }
}
