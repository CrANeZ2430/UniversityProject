using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using University.API.Common.Constants;
using University.Application.Domain.Departments.Commands.CreateDepartment;
using University.API.Domain.Departments.Records;
using University.Application.Domain.Departments.Commands.DeleteDepartment;
using University.Application.Domain.Departments.Commands.UpdateDepartment;

namespace University.API.Domain.Departments;

[Route(Routes.Departments)]
public class DepartmentsController(
    IMediator mediator) 
    : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateDepartment(
        [FromQuery] CreateDepartmentRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new CreateDepartmentCommand(
            request.Title,
            request.Description,
            request.FacultyId);

        var id = await mediator.Send(command, cancellationToken);

        return Ok(id);
    }

    [HttpPut("{departmentId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateDepartment(
        [FromRoute][Required] Guid departmentId,
        [FromQuery] UpdateDepartmentRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new UpdateDepartmentCommand(
            departmentId,
            request.Title,
            request.Description,
            request.FacultyId);

        await mediator.Send(command, cancellationToken);

        return Ok();
    }

    [HttpDelete("{departmentId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteDepartment(
        [FromRoute][Required] Guid departmentId,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteDepartmentCommand(
            departmentId);

        await mediator.Send(command, cancellationToken);

        return Ok();
    }
}
