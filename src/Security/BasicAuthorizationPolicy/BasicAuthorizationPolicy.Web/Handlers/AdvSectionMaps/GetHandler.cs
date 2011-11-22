namespace BasicAuthorizationPolicy.Web.Handlers.AdvSectionMaps
{
    using System;
    using FubuMVC.Core.Security;
    using Security;

    [AllowRole(RoleReference.Maps)]
    public class GetHandler
    {
        public AdvSectionMapsViewModel Execute()
        {
            return new AdvSectionMapsViewModel();
        }
    }
}