namespace ProApiFull.Shared.Consts;

public static class Permissions
{
    public static string Type { get; } = "permissions";

    public const string GetCategories = "category-read";
    public const string AddCategories = "category-add";
    public const string UpdateCategories = "category-update";
    public const string DeleteCategories = "category-delete";

    public const string GetProducts = "Product-read";
    public const string AddProducts = "Product-add";
    public const string UpdateProducts = "Product-update";
    public const string DeleteProductss = "Product-delete";




    public static IList<string?> GetAllPermissions() =>
        typeof(Permissions).GetFields().Select(x => x.GetValue(x) as string).ToList();

}