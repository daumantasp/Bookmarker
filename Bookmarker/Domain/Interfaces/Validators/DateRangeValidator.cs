namespace Bookmarker.Domain.Interfaces.Validation
{
    internal class DateRangeValidator : IValidator<DateTime, DateTime>
    {
        public bool Validate(DateTime start, DateTime end)
        {
            return start <= end;
        }
    }
}
