using CleanArchitecture.Application.Common.Services;

namespace CleanArchitecture.Infrastructure.Services;

public class DateTimeProvider: IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
}