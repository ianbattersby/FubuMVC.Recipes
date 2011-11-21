namespace CustomAuthorizationPolicy.Web.Handlers.AdvSectionOne
{
    using System;
    using Security;

    [AccessGroup(AccessGroupReference.Advanced)]
    public class GetHandler
    {
        public AdvSectionOneViewModel Execute()
        {
            return new AdvSectionOneViewModel();
        }
    }
}