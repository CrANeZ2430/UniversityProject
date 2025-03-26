using MediatR;
using University.Core.Common;
using University.Core.Domain.Faculties.Common;
using University.Core.Domain.Faculties.Data;

namespace University.Application.Domain.Faculties.Commands.UpdateFaculty;

public class UpdateFacultyCommandHandler(
    IFacultiesRepository facultiesRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateFacultyCommand>
{
    public async Task Handle(
        UpdateFacultyCommand command, 
        CancellationToken cancellationToken = default)
    {
        var faculty = await facultiesRepository.GetById(command.FacultyId, cancellationToken);

        var data = new UpdateFacultyData(
            command.Title,
            command.Description);

        await faculty.Update(data, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
