namespace BasicAuthorizationPolicy.Web.Handlers.AdvSectionOne
{
    using System;
    using FubuMVC.Core.Security;
    using Security;

    [AllowRole(RoleReference.Advanced)]
    public class GetHandler
    {
        public AdvSectionOneViewModel Execute()
        {
            return new AdvSectionOneViewModel();
        }
    }
}