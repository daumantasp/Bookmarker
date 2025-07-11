namespace Bookmarker.Application.Validators
{
    internal interface IControlValidator<T>
    {
        ValidationResult Validate(T value);
    }
}