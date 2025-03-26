using MediatR;
using University.Application.Common;

namespace University.Application.Domain.Students.Query.GetGroupStudents;

public record GetGroupStudentsQuery(
    Guid GroupId,
    int Page,
    int PageSize)
    : IRequest<PageResponse<GroupStudentDto[]>>;
