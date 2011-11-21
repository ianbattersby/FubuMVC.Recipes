namespace CustomAuthorizationPolicy.Web.Security
{
    using System;

    public interface IFormsAuthenticationWrapper
    {
        void SetAuthCookie(string userName, bool createPersistentCookie);
        void SetAuthCookie(string userName, bool createPersistentCookie, string strCookiePath);
        void SignOut();
    }
}
