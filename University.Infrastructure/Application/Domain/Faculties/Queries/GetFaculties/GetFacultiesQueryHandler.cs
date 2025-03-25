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
            .Include(x => x.Departments)
            .ThenInclude(x => x.Groups)
            .AsNoTracking();

        var skip = query.PageSize * (query.Page - 1);

        var count = await sqlQuery.CountAsync(cancellationToken);

        var faculties = await sqlQuery
            .OrderBy(x => x.Title)
            .Skip(skip)
            .Take(query.PageSize)
            .Select(x => new FacultyDto(
                x.FacultyId,
                x.Title,
                x.Description,
                x.Departments
                .Select(x => new DepartmentDto(
                    x.DepartmentId,
                    x.Title,
                    x.Description,
                    x.Groups
                    .Select(x => new GroupDto(
                        x.GroupId,
                        x.Name,
                        x.MaxStudents,
                        42))
                    .ToArray()))
                .ToArray()))
            .ToArrayAsync(cancellationToken);

        return new PageResponse<FacultyDto[]>(count, faculties);
    }
}
