﻿namespace ProApiFull.Service.Abstractions.Paginations;
public class RequestFilters
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string? Search { get; init; }
    public string? SortColmin { get; init; }
    public string? SortDirection { get; init; } = "ASC";
}
