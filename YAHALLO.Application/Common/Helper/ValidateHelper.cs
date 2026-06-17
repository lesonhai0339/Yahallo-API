namespace YAHALLO.Application.Common.Helper
{
    internal static class ValidateHelper
    {
        internal static bool IsEmailValidate(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email.Trim(); 
            }
            catch
            {
                return false;
            }
        }
      
    }
}
