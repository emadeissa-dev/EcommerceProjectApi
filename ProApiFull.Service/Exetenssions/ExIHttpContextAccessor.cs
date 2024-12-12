

namespace ProApiFull.Service.Exetenssions;

public static class ExIHttpContextAccessor
{
    public static string ExAccessFullPathAction(this IHttpContextAccessor context, IUrlHelper urlHelper, string contollerName, string actionName, string IdOrEmail, string code, StateAccess state)
    {
        var httpContext = context.HttpContext!.Request;
        if (state == StateAccess.sendToemail)
            return $"{httpContext.Scheme}://{httpContext.Host}{urlHelper.Action(actionName, contollerName, new { UserId = IdOrEmail, Code = code })}";

        if (state == StateAccess.sendTopassword)
            return $"{httpContext.Scheme}://{httpContext.Host}{urlHelper.Action(actionName, contollerName, new { Email = IdOrEmail, Code = code })}";


        return string.Empty;

    }
}
