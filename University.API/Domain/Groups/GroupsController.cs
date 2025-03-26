using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using University.API.Common.Constants;
using University.API.Domain.Groups.Records;
using University.Application.Common;
using University.Application.Domain.Groups.Commands.CreateGroup;
using University.Application.Domain.Groups.Commands.DeleteCommand;
using University.Application.Domain.Students.Query.GetGroupStudents;

namespace University.API.Domain.Groups
{
    [Route(Routes.Groups)]
    public class GroupsController(
        IMediator mediator) 
        : ControllerBase
    {
        [HttpGet("{groupId}")]
        [ProducesResponseType(typeof(PageResponse<GroupStudentDto[]>) ,StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGroupStudents(
            [FromRoute][Required] Guid groupId,
            [FromQuery][Required] int page = 1,
            [FromQuery][Required] int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            var query = new GetGroupStudentsQuery(
                groupId,
                page,
                pageSize);

            var result = await mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
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
