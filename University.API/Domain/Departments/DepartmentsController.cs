using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using University.API.Common.Constants;
using University.Application.Domain.Departments.Commands.CreateDepartment;
using University.API.Domain.Departments.Records;
using University.Application.Domain.Departments.Commands.DeleteDepartment;

namespace University.API.Domain.Departments;

[Route(Routes.Departments)]
public class DepartmentsController(
    IMediator mediator) : ControllerBase
{
    [HttpPost]
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

    [HttpDelete("{departmentId}")]
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
