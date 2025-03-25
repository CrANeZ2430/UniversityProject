using System.Net;

namespace University.Infrastructure.Middleware;

public record ExceptionResponse(
    HttpStatusCode StatusCode, 
    object Data);
