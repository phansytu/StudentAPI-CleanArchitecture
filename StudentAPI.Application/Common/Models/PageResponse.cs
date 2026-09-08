namespace StudentAPI.Application.Common.Models;

public record PageResponse<T>(List<T> Items, int TotalCount, int PageIndex, int PageSize)
{
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public bool HasNextPage => PageIndex < TotalPages;
    public bool HasPreviousPage => PageIndex > 1;
}