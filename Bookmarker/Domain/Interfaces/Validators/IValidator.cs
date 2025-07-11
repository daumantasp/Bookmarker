namespace Bookmarker.Domain.Interfaces.Validation
{
    internal interface IValidator<T>
    {
        bool Validate(T input);
    }
}
