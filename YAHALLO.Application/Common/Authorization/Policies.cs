namespace YAHALLO.Application.Common.Authorization
{
    /// <summary>
    /// Tên các authorization policy (khai báo trong ConfigureAuthorization).
    /// Dùng const string thay magic string — xài được cả [Authorize(Policy = ...)]
    /// lẫn AuthorizeAsync(...).
    /// </summary>
    public static class Policies
    {
        public const string Admin = "Admin";
        public const string Mod = "Mod";
        public const string User = "User";
        public const string Trans = "Trans";
        public const string ModOrAdmin = "ModOrAdmin";
    }
}
