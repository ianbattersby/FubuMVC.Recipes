namespace CustomAuthorizationPolicy.Web.Handlers.AdvSectionMaps
{
    using System;
    using Security;

    [AccessGroup(AccessGroupReference.Advanced, AccessGroupReference.Maps)]
    public class GetHandler
    {
        public AdvSectionMapsViewModel Execute()
        {
            return new AdvSectionMapsViewModel();
        }
    }
}