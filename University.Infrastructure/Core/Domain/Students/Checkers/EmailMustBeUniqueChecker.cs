using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Students.Checkers;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Students.Checkers;

public class EmailMustBeUniqueChecker(
    UniversityDbContext dbContext)
    : IEmailMustBeUniqueChecker
{
    public async Task<bool> IsUnique(string email, CancellationToken cancellationToken = default)
    {
        return await dbContext.Students.AllAsync(x => x.Email != email, cancellationToken);
    }
}
