using Bookmarker.Domain.Interfaces.Validation;

namespace Bookmarker.Application.Validators
{
    internal class ControlValidator<T> : IControlValidator<T>
    {
        private readonly Control _control;
        private readonly IValidator<T> _validator;
        private readonly string _errorMessage;

        public ControlValidator(Control control,
                                IValidator<T> validator,
                                string errorMessage)
        {
            _control = control;
            _validator = validator;
            _errorMessage = errorMessage;
        }

        public ValidationResult Validate(T value)
        {
            if (_validator.Validate(value))
            {
                return ValidationResult.Success();
            }
            else
            {
                return ValidationResult.Failure(_errorMessage);
            }
        }
    }

    internal class ControlValidator<T1, T2> : IControlValidator<T1, T2>
    {
        private readonly Control _control;
        private readonly IValidator<T1, T2> _validator;
        private readonly string _errorMessage;

        public ControlValidator(Control control,
                                IValidator<T1, T2> validator,
                                string errorMessage)
        {
            _control = control;
            _validator = validator;
            _errorMessage = errorMessage;
        }

        public ValidationResult Validate(T1 value1, T2 value2)
        {
            if (_validator.Validate(value1, value2))
            {
                return ValidationResult.Success();
            }
            else
            {
                return ValidationResult.Failure(_errorMessage);
            }
        }
    }
}
