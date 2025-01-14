﻿namespace ProApiFull.Domin.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
    public List<RefreshToken> RefreshTokens { get; set; } = [];
}
