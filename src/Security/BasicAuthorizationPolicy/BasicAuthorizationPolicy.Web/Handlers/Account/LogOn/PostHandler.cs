namespace BasicAuthorizationPolicy.Web.Handlers.Account.LogOn
{
    using System;
    using System.Linq;
    using System.Web.Security;
    using FubuMVC.Core.Continuations;
    using FubuMVC.Core.Security;
    using Security;
    using Home = Handlers.Home;

    public class PostHandler
    {
        private readonly IUserData userData;
        private readonly IAuthenticationContext authContext;

        public PostHandler(
            IAuthenticationContext authContext, 
            IUserData userdata)
        {
            this.authContext = authContext;
            this.userData = userdata;
        }

        public FubuContinuation Execute(LogOnRequestModel model)
        {
            if (!String.IsNullOrWhiteSpace(model.Name) && !String.IsNullOrWhiteSpace(model.Password))
            {
                var username= model.Name.Trim();

                authContext.ThisUserHasBeenAuthenticated(username, false);

                if (userData.AllowedGroups.ContainsKey(username))
                {
                    Roles.AddUserToRoles(username, userData.AllowedGroups[username].ToArray());
                }

                // TODO: We should be able to redirect based on ViewModel-In, but
                // FubuContinuation assetions don't like. Must investigate!
                return FubuContinuation.RedirectTo<Home.GetHandler>(x => x.Execute());
            }

            return FubuContinuation.RedirectTo<LogOn.GetHandler>(x => x.Execute());
        }
    }
}