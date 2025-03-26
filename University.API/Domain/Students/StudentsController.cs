using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using University.API.Common.Constants;
using University.API.Domain.Students.Records;
using University.Application.Domain.Students.Commands.CreateStudent;
using University.Application.Domain.Students.Commands.DeleteStudent;

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
}
