using MediatR;
using University.Application.Common;

namespace University.Application.Domain.Faculties.Queries.GetFaculties;

public record GetFacultiesQuery(
    int Page,
    int PageSize)
    : IRequest<PageResponse<FacultyDto[]>>;
