using System.Security.Claims;
using System.Security.Principal;

namespace WebAppFovimeFrontEnd.Helpers
{
    public class UserLogin
    {        

        public static string GetIdUser(IPrincipal idUser)
        {
            var r = ((ClaimsIdentity)idUser.Identity).FindFirst(ClaimTypes.NameIdentifier);
            return r == null ? "" : r.Value;
        }
        public static string GetNameUser(IPrincipal idUser)
        {
            var r = ((ClaimsIdentity)idUser.Identity).FindFirst(ClaimTypes.Name);
            return r == null ? "" : r.Value;
        }
        public static string GetRolUser(IPrincipal idUser)
        {
            var r = ((ClaimsIdentity)idUser.Identity).FindFirst(ClaimTypes.Role);
            return r == null ? "" : r.Value;
        }
        public static string GetValueUser(IPrincipal idUser, string property)
        {
            var r = ((ClaimsIdentity)idUser.Identity).FindFirst(property);
            return r == null ? "" : r.Value;
        }

    }
}
