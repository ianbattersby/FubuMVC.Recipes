namespace IRedirectableRecipe.Web.Handlers.Home
{
    using FubuMVC.Core.Continuations;

    public class HomeViewModel : IRedirectable
    {
        public FubuContinuation RedirectTo { get; set; }
    }
}