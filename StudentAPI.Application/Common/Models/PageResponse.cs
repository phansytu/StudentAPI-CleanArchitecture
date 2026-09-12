namespace StudentAPI.Application.Common.Models;

public class PageResponse<T>
{
    public IEnumerable<T> Items { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);

    public PageResponse(IEnumerable<T> items, int totalRecords, int pageIndex, int pageSize)
    {
        Items = items;
        TotalRecords = totalRecords;
        PageIndex = pageIndex;
        PageSize = pageSize;
    }
}