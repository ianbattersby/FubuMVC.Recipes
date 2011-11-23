namespace FubuMVCContinuation.Web.Handlers.Home
{
    using System;
    using DeadEnd = FubuMVCContinuation.Web.Handlers.DeadEnd;
    using FubuMVC.Core.Continuations;

    public class PostHandler
    {
        public const string RedirectConfirm = @"REDIRECT";

        public FubuContinuation Execute(HomeRequestModel model)
        {
            if (model.RedirectConfirmation.Equals(RedirectConfirm, StringComparison.CurrentCultureIgnoreCase))
            {
                return FubuContinuation.RedirectTo<DeadEnd.GetHandler>(x => x.Execute(new DeadEnd.DeadEndViewModel()));
            }

            if (model.StatusCode > 0)
            {
                System.Net.HttpStatusCode httpStatusCode;

                if (!Enum.TryParse(model.StatusCode.ToString(), out httpStatusCode))
                {
                    throw new ArgumentException("StatusCode not valid");
                }

                if (!Enum.IsDefined(typeof(System.Net.HttpStatusCode), httpStatusCode))
                {
                    throw new ArgumentException("StatusCode not listed");
                }

                return FubuContinuation.EndWithStatusCode(httpStatusCode);
            }

            return FubuContinuation.RedirectTo<Home.GetHandler>(x => x.Execute());
        }
    }
}