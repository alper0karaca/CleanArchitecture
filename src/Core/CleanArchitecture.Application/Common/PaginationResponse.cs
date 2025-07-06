namespace CleanArchitecture.Application.Common;

public class PaginationResponse<T>
{
    public PaginationResponse(IEnumerable<T> items, int count, int pageNumber, int pageSize)
    {
        Items = items.ToList();
        TotalCount = count;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
    
    public IReadOnlyList<T> Items { get; set; } = [];
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    
}