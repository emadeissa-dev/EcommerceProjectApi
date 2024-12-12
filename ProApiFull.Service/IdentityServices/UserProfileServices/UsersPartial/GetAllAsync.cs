namespace ProApiFull.Service.IdentityServices;
public partial class UserService
{
    public async Task<IEnumerable<UserResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var users = await (
            from u in context.Users
            join ur in context.UserRoles
            on u.Id equals ur.UserId
            join r in context.Roles
            on ur.RoleId equals r.Id into roles
            where !roles.Any(x => x.Name == DefaultRoles.Member)
            select new
            {
                u.Id,
                u.FirstName,
                u.LastName,
                u.IsDeleted,
                Email = u.Email!,
                Roles = roles.Select(x => x.Name!).ToList()
            })
            .GroupBy(x => new { x.Id, x.FirstName, x.LastName, x.IsDeleted, x.Email })
            .Select(x => new UserResponse
            {
                Id = x.Key.Id,
                FirstName = x.Key.FirstName,
                LastName = x.Key.LastName,
                IsDisabled = x.Key.IsDeleted,
                Email = x.Key.Email!,
                Roles = x.SelectMany(x => x.Roles)
            }).ToListAsync(cancellationToken);




        return users;
    }
}
