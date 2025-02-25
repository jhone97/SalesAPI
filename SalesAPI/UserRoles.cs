using Microsoft.AspNetCore.Identity;

namespace SalesAPI
{
    public class UserRoles : IdentityRole
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
