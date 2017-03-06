using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GildedRose.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        public IHttpActionResult ExternalLogin()
        {
            return new ChallengeResult("Google", "/", this.Request);
        }

        [Route("api/logout")]
        [HttpGet]
        public void ExternalLogout()
        {
            Request.GetOwinContext().Authentication.SignOut();
        }

        [Route("api/isLoggedIn")]
        [HttpGet]
        public bool IsLoggedIn()
        {
            if (Request != null)
            {
                var userName = Request.GetOwinContext().Authentication.User.Identity.Name;
                if (!string.IsNullOrEmpty(userName))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
