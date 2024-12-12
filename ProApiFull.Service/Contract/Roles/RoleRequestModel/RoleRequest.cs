namespace ProApiFull.Service.Contract.Roles;
public class RoleRequest
{
    public string Name { get; set; } = string.Empty;
    public IEnumerable<string> Permissions { get; set; } = [];
}
