﻿namespace ProApiFull.Service.Contract;
public class RoleResponse
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
}