﻿namespace ProApiFull.Domin.Entities;
public class Category : AuditableEntity
{
    public int Id { get; set; }
    public string NameEn { get; set; } = string.Empty;
    public string NameAr { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;

    public List<Product> Products { get; set; } = [];
}
