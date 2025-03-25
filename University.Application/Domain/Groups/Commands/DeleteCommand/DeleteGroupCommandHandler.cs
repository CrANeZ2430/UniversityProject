using MediatR;
using University.Core.Common;
using University.Core.Domain.Groups.Common;

namespace University.Application.Domain.Groups.Commands.DeleteCommand;

public class DeleteGroupCommandHandler(
    IGroupsRepository groupsRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteGroupCommand>
{
    public async Task Handle(
        DeleteGroupCommand command, 
        CancellationToken cancellationToken = default)
    {
        var group = await groupsRepository.GetById(command.GroupId);

        groupsRepository.Remove(group);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
