using System.Text.RegularExpressions;

namespace Customer.Domain.SeedWorks;
public static class CommonArgumentValidation
{
    public static bool IsValidEmail(string email)
    {
        string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        Match match = Regex.Match(email, pattern);
        return match.Success;
    }
}
