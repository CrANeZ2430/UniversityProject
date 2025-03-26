using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Common;
using University.Application.Domain.Students.Query.GetGroupStudents;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Application.Domain.Students.Queries.GetGroupStudents;

public class GetGroupStudentsQueryHandler(
    UniversityDbContext dbContext)
    : IRequestHandler<GetGroupStudentsQuery, PageResponse<GroupStudentDto[]>>
{
    public async Task<PageResponse<GroupStudentDto[]>> Handle(
        GetGroupStudentsQuery query, 
        CancellationToken cancellationToken = default)
    {
        var sqlQuery = dbContext.Students
            .AsNoTracking()
            .Where(s => s.GroupId == query.GroupId)
            .OrderBy(s => s.FirstName)
            .Select(s => new GroupStudentDto(
                s.StudentId,
                s.FirstName,
                s.LastName,
                s.MiddleName,
                s.Email,
                s.PhoneNumber));

        var count = await sqlQuery
                .CountAsync(cancellationToken);

        var students = await sqlQuery
                .Skip(query.PageSize * (query.Page - 1))
                .Take(query.PageSize)
                .ToArrayAsync(cancellationToken);


        return new PageResponse<GroupStudentDto[]>(count, students);
    }
}
