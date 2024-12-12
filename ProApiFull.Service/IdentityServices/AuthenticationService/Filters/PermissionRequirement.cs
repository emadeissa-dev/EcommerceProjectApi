using Microsoft.AspNetCore.Authorization;

namespace ProApiFull.Service.IdentityServices.AuthenticationService.Filters;


public class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}