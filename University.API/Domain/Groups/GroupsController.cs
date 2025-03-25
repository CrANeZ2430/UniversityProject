using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using University.API.Common.Constants;
using University.API.Domain.Groups.Records;
using University.Application.Domain.Groups.Commands.CreateGroup;
using University.Application.Domain.Groups.Commands.DeleteCommand;

namespace University.API.Domain.Groups
{
    [Route(Routes.Groups)]
    public class GroupsController(
        IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateGroup(
            [FromQuery] CreateGroupRequest request,
            CancellationToken cancellationToken = default)
        {
            var command = new CreateGroupCommand(
                request.Name,
                request.MaxStudents,
                request.DepartmentId);

            var id = await mediator.Send(command);

            return Ok(id);
        }

        [HttpDelete("{groupId}")]
        public async Task<IActionResult> DeleteGroup(
            [FromRoute][Required] Guid groupId,
            CancellationToken cancellationToken = default)
        {
            var command = new DeleteGroupCommand(
                groupId);

            await mediator.Send(command, cancellationToken);

            return Ok();
        }
    }
}
