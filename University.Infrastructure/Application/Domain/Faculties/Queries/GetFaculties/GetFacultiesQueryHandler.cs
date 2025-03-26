using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Application.Common;
using University.Application.Domain.Faculties.Queries.GetFaculties;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Application.Domain.Faculties.Queries.GetFaculties;

public class GetFacultiesQueryHandler(
    UniversityDbContext dbContext) 
    : IRequestHandler<GetFacultiesQuery, PageResponse<FacultyDto[]>>
{
    public async Task<PageResponse<FacultyDto[]>> Handle(
        GetFacultiesQuery query, 
        CancellationToken cancellationToken = default)
    {
        var sqlQuery = dbContext
            .Faculties
            .AsNoTracking();

        var skip = query.PageSize * (query.Page - 1);
        var count = await sqlQuery.CountAsync(cancellationToken);

        var faculties = await sqlQuery
            .OrderBy(f => f.Title)
            .Skip(skip)
            .Take(query.PageSize)
            .Select(f => new FacultyDto(
                f.FacultyId,
                f.Title,
                f.Description,
                f.Departments.Select(d => new DepartmentDto(
                    d.DepartmentId,
                    d.Title,
                    d.Description,
                    d.Groups.Select(g => new GroupDto(
                        g.GroupId,
                        g.Name,
                        g.MaxStudents,
                        g.Students.Count(),
                        g.Students.Select(s => new StudentDto(
                            s.FirstName,
                            s.LastName,
                            s.MiddleName))
                        .ToArray()))
                    .ToArray()))
                .ToArray()))
            .ToArrayAsync(cancellationToken);

        return new PageResponse<FacultyDto[]>(count, faculties);
    }
}
