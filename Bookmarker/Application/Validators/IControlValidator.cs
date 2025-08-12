namespace Bookmarker.Application.Validators
{
    internal interface IControlValidator<T>
    {
        ValidationResult Validate(T value);
    }

    internal interface IControlValidator<T1, T2>
    {
        ValidationResult Validate(T1 value1, T2 value2);
    }
}