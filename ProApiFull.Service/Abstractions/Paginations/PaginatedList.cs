namespace ProApiFull.Service.Abstractions.Paginations;
public class PaginatedList<T>
{
    public PaginatedList(List<T> items, int pageNumber, int count, int pageSize, int countSourse)
    {
        Items = items;
        PageNumber = pageNumber;
        TotalPage = (int)Math.Ceiling(count / (double)pageSize);
        CountSourse = countSourse;
    }
    public List<T> Items { get; private set; }
    public int PageNumber { get; private set; }
    public int TotalPage { get; private set; }
    public int CountSourse { get; private set; }
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPage;


    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> sourse, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        var count = await sourse.CountAsync(cancellationToken);
        var items = await sourse.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

        return new(items, pageNumber, count, pageSize, count);
    }
}
