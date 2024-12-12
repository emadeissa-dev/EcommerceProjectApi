namespace ProApiFull.Service.Exetenssions;
public static class ExClaimsPrincipal
{
    public static string ExGetCurrentUserId(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier)!;
    }

}
