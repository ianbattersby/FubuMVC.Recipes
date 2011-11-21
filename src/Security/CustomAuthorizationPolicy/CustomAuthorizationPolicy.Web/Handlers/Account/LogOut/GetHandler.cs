namespace CustomAuthorizationPolicy.Web.Handlers.Account.LogOut
{
    using System;
    using FubuMVC.Core.Continuations;
    using Security;

    [AccessGroup(AccessGroupReference.Basic)]
    public class GetHandler
    {
        private readonly IFormsAuthenticationWrapper formsAuthenticationWrapper;

        public GetHandler(IFormsAuthenticationWrapper formsAuthenticationWrapper)
        {
            this.formsAuthenticationWrapper = formsAuthenticationWrapper;
        }

        public FubuContinuation Execute()
        {
            formsAuthenticationWrapper.SignOut();

            return FubuContinuation.RedirectTo<LogOn.GetHandler>(x => x.Execute());
        }
    }
}