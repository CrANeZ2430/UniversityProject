using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using University.API.Common.Constants;
using University.API.Domain.Faculties.Records;
using University.Application.Common;
using University.Application.Domain.Faculties.Commands.CreateFaculty;
using University.Application.Domain.Faculties.Commands.DeleteFaculty;
using University.Application.Domain.Faculties.Queries.GetFaculties;

namespace University.API.Domain.Faculties;

[Route(Routes.Faculties)]
public class FacultiesController(
    IMediator mediator) 
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<FacultyDto[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFaculties(
        [FromQuery][Required] int page = 1,
        [FromQuery][Required] int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetFacultiesQuery(
            page,
            pageSize);

        var result = await mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateFaculty(
        [FromQuery] CreateFacultyRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new CreateFacultyCommand(
            request.Title,
            request.Description);

        var id = await mediator.Send(command, cancellationToken);

        return Ok(id);
    }

    [HttpDelete("{facultyId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteFaculty(
        [FromRoute][Required] Guid facultyId,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteFacultyCommand(
            facultyId);

        await mediator.Send(command, cancellationToken);

        return Ok();
    }
}
