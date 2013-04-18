using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;

namespace Site.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
           FormsAuthentication.SignOut();
            Request.Cookies.AllKeys.ToList().ForEach(x => Response.Cookies.Add(new HttpCookie(x) {Expires = DateTime.Now.AddDays(-30)}));

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            var result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            FormsAuthentication.SetAuthCookie(result.UserName, false);
            return RedirectToLocal(returnUrl);
            
        }

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }

    internal class ExternalLoginResult : ActionResult
    {
        public ExternalLoginResult(string provider, string returnUrl)
        {
            Provider = provider;
            ReturnUrl = returnUrl;
        }

        private string Provider { get; set; }
        private string ReturnUrl { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
        }
    }
}
