namespace YAHALLO.Common
{ 
    public class AuthCookieOptions
    { 
        public string? Domain { get; set; }   
        public bool Secure { get; set; }
        public string SameSite { get; set; } = "Lax";
    }
}
