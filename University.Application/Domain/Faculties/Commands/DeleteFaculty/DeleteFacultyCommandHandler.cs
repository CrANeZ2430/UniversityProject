using MediatR;
using University.Core.Common;
using University.Core.Domain.Faculties.Common;

namespace University.Application.Domain.Faculties.Commands.DeleteFaculty;

public class DeleteFacultyCommandHandler(
    IUnitOfWork unitOfWork,
    IFacultiesRepository facultiesRepository)
    : IRequestHandler<DeleteFacultyCommand>
{
    public async Task Handle(DeleteFacultyCommand command, CancellationToken cancellationToken = default)
    {
        var faculty = await facultiesRepository.GetById(command.facultyId, cancellationToken);

        facultiesRepository.Remove(faculty);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
