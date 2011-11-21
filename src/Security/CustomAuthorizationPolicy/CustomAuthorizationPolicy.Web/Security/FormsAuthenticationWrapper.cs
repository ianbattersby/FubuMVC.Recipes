namespace CustomAuthorizationPolicy.Web.Security
{
    using System;
    using System.Web.Security;

    public class FormsAuthenticationWrapper : IFormsAuthenticationWrapper
    {
        public void SetAuthCookie(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SetAuthCookie(string userName, bool createPersistentCookie, string strCookiePath)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie, strCookiePath);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}