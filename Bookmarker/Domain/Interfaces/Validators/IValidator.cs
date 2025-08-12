namespace Bookmarker.Domain.Interfaces.Validation
{
    internal interface IValidator<T>
    {
        bool Validate(T input);
    }

    internal interface IValidator<T1, T2>
    {
        bool Validate(T1 input1, T2 input2);
    }
}
