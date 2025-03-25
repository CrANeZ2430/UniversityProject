using System.Net;
using University.Core.Exceptions;

namespace University.Infrastructure.Middleware;

public class ExceptionToResponseMapper : IExceptionToResponseMapper
{
    public ExceptionResponse Map(Exception exception)
    {
        return exception switch
        {
            NotFoundException ex => new ExceptionResponse(
                HttpStatusCode.NotFound,
                new
                {
                    ex.Message
                }),
            AlreadyExistsException ex => new ExceptionResponse(
                HttpStatusCode.Conflict,
                new
                {
                    ex.Details,
                    ex.Message
                }),
            BadRequestException ex => new ExceptionResponse(
                HttpStatusCode.BadRequest,
                new
                {
                    ex.Message
                }),

            ValidationException ex => new ExceptionResponse(
                HttpStatusCode.BadRequest,
                new
                {
                    ex.Message,
                    Errors = ex.Failures
                        .Select(e => new
                        {
                            e.PropertyName,
                            e.ErrorMessage
                        })
                        .ToList()
                }),

            RuleValidationException ex => new ExceptionResponse(
                HttpStatusCode.BadRequest,
                new
                {
                    ex.Message,
                    Errors = ex.Failures
                }),

            _ => new ExceptionResponse(
                HttpStatusCode.InternalServerError,
                new
                {
                    exception.Message,
                    exception.StackTrace
                })
        };
    }
}
