namespace BasicAuthorizationPolicy.Web.Handlers.Account.LogOut
{
    using System;
    using FubuMVC.Core.Continuations;
    using FubuMVC.Core.Security;

    public class GetHandler
    {
        private readonly IAuthenticationContext authContext;

        public GetHandler(IAuthenticationContext authContext)
        {
            this.authContext = authContext; ;
        }

        public FubuContinuation Execute(LogOutRequestModel model)
        {
            authContext.SignOut();

            return FubuContinuation.RedirectTo<LogOn.GetHandler>(x => x.Execute());
        }
    }
}