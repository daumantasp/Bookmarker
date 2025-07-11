using Bookmarker.Domain.Interfaces.Validation;

namespace Bookmarker.Domain.Interfaces.Validators
{
    internal class TagsValidator : IValidator<string>
    {
        public bool Validate(string input)
        {
            if (string.IsNullOrEmpty(input))
                return true;

            var tags = input.Split(',')
                .ToList();

            if (tags.Count == 0)
                return false;

            foreach (var tag in tags)
            {
                var trimmed = tag.Trim();

                if (string.IsNullOrWhiteSpace(trimmed))
                    return false;

                if (!trimmed.StartsWith("#"))
                    return false;

                if (trimmed.Length < 2)
                    return false;

                if (trimmed.Substring(1).Any(c => !char.IsLetterOrDigit(c) && c != '-' && c != '_'))
                    return false;
            }

            return true;
        }
    }
}
