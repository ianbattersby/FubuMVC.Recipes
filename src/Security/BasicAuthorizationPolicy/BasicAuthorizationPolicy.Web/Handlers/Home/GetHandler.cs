namespace BasicAuthorizationPolicy.Web.Handlers.Home
{
    using System;
    using FubuMVC.Core.Security;
    using Security;

    [AllowRole(RoleReference.Basic)]
    public class GetHandler
    {
        public HomeViewModel Execute()
        {
            return new HomeViewModel();
        }
    }
}