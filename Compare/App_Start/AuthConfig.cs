using Microsoft.Web.WebPages.OAuth;

namespace Site.App_Start
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}