using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using University.API.Common.Constants;
using University.API.Domain.Students.Records;
using University.Application.Domain.Students.Commands.CreateStudent;
using University.Application.Domain.Students.Commands.DeleteStudent;
using University.Application.Domain.Students.Commands.ReassignGroup;
using University.Application.Domain.Students.Commands.UpdateStudent;

namespace University.API.Domain.Students;

[Route(Routes.Students)]
public class StudentsController(
    IMediator mediator) 
    : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateStudent(
        [FromQuery] CreateStudentRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new CreateStudentCommand(
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Email,
            request.PhoneNumber,
            request.GroupId);

        var id = await mediator.Send(command, cancellationToken);

        return Ok(id);
    }

    [HttpPut("{studentId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateStudent(
        [FromRoute][Required] Guid studentId,
        [FromQuery] UpdateStudentRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new UpdateStudentCommand(
            studentId,
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Email,
            request.PhoneNumber,
            request.GroupId);

        await mediator.Send(command, cancellationToken);

        return Ok();
    }

    [HttpDelete("{studentId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteStudent(
        [FromRoute][Required] Guid studentId,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteStudentCommand(
            studentId);

        await mediator.Send(command, cancellationToken);

        return Ok();
    }

    [HttpPut("reassign-group/{studentId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ReassignGroup(
        [FromRoute][Required] Guid studentId,
        [FromQuery][Required] Guid groupId,
        CancellationToken cancellationToken = default)
    {
        var command = new ReassignGroupCommand(studentId, groupId);

        await mediator.Send(command, cancellationToken);

        return Ok();
    }
}
