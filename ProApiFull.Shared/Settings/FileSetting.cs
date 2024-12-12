﻿namespace ProApiFull.Shared.Settings;

public class FileSetting
{
    public const int MaxFileSizeInMB = 1;
    public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
    public static readonly string[] BlockedSignatures = ["4D-5A", "2F-2A", "D0-CF"];
    public static readonly string[] AllowedImagesExtensions = [".jpg", ".jpeg", ".png"];
}
