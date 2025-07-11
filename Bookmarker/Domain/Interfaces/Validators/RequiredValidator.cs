namespace Bookmarker.Domain.Interfaces.Validation
{
    internal class RequiredValidator : IValidator<string>
    {
        public bool Validate(string input) => !string.IsNullOrWhiteSpace(input);
    }
}
