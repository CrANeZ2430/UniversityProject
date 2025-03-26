using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Students.Checkers;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Students.Checkers;

public class PhoneMustBeUniqueChecker(
    UniversityDbContext dbContext)
    : IPhoneMustBeUniqueChecker
{
    public async Task<bool> IsUnique(string phoneNumber, CancellationToken cancellationToken)
    {
        return await dbContext.Students.AllAsync(x => x.PhoneNumber != phoneNumber, cancellationToken);
    }
}
