using Microsoft.AspNet.Identity;
using MoodTracker.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodTracker.Web.UI.Helper
{
    public class AuthenticatedUserInfo : IAuthenticatedUser<int>
    {
        public string Id
        {
            get
            {
                return HttpContext.Current.User.Identity.GetUserId();
            }
        }

        public string Username
        {
            get
            {
                string Username = "";
                try
                {
                    Username = HttpContext.Current.User.Identity.Name;

                }
                catch
                {
                    Username = "";
                }
                return Username;
            }
        }

        public string Email
        {
            get
            {
                string Email = "";
                try
                {
                    Email = HttpContext.Current.User.Identity.Name;

                }
                catch
                {
                    Email = "";
                }
                return Email;
            }
        }
    }
}