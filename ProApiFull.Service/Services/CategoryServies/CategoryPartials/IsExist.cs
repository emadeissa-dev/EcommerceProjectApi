namespace ProApiFull.Service.Services;
public partial class CategoryService
{
    public bool IsExist(int Id)
    {
        return _category.Entity
        .GetTableNoTracking().Any(x => x.Id == Id && !x.IsDeleted);
    }
}