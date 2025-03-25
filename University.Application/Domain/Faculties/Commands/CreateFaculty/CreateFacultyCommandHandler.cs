using MediatR;
using University.Core.Common;
using University.Core.Domain.Faculties.Common;
using University.Core.Domain.Faculties.Data;
using University.Core.Domain.Faculties.Models;

namespace University.Application.Domain.Faculties.Commands.CreateFaculty;

public class CreateFacultyCommandHandler(
    IUnitOfWork unitOfWork,
    IFacultiesRepository facultiesRepository)
    : IRequestHandler<CreateFacultyCommand, Guid>
{
    public async Task<Guid> Handle(CreateFacultyCommand command, CancellationToken cancellationToken)
    {
        var data = new CreateFacultyData(
            command.Title,
            command.Description);

        var faculty = await Faculty.Create(data);

        await facultiesRepository.Add(faculty);
        await unitOfWork.SaveChangesAsync();

        return faculty.FacultyId;
    }
}
