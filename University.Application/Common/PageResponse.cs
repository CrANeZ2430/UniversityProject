namespace University.Application.Common;

public record PageResponse<T>(
    int Count,
    T Result)
    where T : class;
