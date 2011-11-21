namespace CustomAuthorizationPolicy.Web.Handlers.Account.LogOn
{
    using System;
    using FubuMVC.Core.Continuations;
    using Security;
    using Home = Handlers.Home;
    using System.Web.Security;

    [AccessGroup]
    public class PostHandler
    {
        private readonly IFormsAuthenticationWrapper formsAuthenticationWrapper;

        public PostHandler(IFormsAuthenticationWrapper formsAuthenticationWrapper)
        {
            this.formsAuthenticationWrapper = formsAuthenticationWrapper;
        }

        public FubuContinuation Execute(LogOnRequestModel model)
        {
            if (!String.IsNullOrWhiteSpace(model.Name) && !String.IsNullOrWhiteSpace(model.Password))
            {
                formsAuthenticationWrapper.SetAuthCookie(model.Name.Trim(), false);

                // TODO: We should be able to redirect based on ViewModel-In, but
                // FubuContinuation assetions don't like. Must investigate!
                return FubuContinuation.RedirectTo<Home.GetHandler>(x => x.Execute());
            }

            return FubuContinuation.RedirectTo<LogOn.GetHandler>(x => x.Execute());
        }
    }
}