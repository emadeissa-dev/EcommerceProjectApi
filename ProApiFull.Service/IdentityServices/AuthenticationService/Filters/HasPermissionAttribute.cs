using Microsoft.AspNetCore.Authorization;

namespace ProApiFull.Service.IdentityServices.AuthenticationService.Filters;


public class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission)
{
}