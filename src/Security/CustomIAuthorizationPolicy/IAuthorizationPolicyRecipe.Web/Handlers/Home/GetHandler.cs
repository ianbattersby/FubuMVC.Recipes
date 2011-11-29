namespace IAuthorizationPolicyRecipe.Web.Handlers.Home
{
    using System;
    using Security;

    [AccessGroup(AccessGroupReference.Basic)]
    public class GetHandler
    {
        public HomeViewModel Execute()
        {
            return new HomeViewModel();
        }
    }
}