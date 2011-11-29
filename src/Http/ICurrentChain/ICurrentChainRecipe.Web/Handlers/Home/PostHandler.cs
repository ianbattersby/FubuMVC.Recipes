namespace ICurrentChainRecipe.Web.Handlers.Home
{
    using System;
    using FubuMVC.Core.Continuations;
    using DeadEnd = Handlers.DeadEnd;

    public class PostHandler
    {
        public FubuContinuation Execute(HomeRequestModel model)
        {
            return FubuContinuation.RedirectTo<DeadEnd.GetHandler>(x => x.Execute());
        }
    }
}