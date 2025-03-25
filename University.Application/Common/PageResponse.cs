namespace University.Application.Common;

public record PageResponse<T>(
    int Count,
    T Data)
    where T : class;
