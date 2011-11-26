namespace FubuMVCIRedirectable.Web.Handlers.Home
{
    using System;
    using FubuMVCIRedirectable.Web.Handlers.DeadEnd;
    using FubuMVC.Core.Continuations;

    public class PostHandler
    {
        public const string RedirectConfirm = @"REDIRECT";

        public HomeViewModel Execute(HomeRequestModel model)
        {
            if (model.RedirectConfirmation.Equals(RedirectConfirm, StringComparison.CurrentCultureIgnoreCase))
            {
                return new HomeViewModel()
                {
                    RedirectTo = FubuContinuation.RedirectTo<DeadEnd.GetHandler>(x => x.Execute(new DeadEndViewModel()))
                };
            }

            return new HomeViewModel();
        }
    }
}