namespace FubuPageExtensionsRecipe.Web.Handlers.Books.Create
{
    using FubuMVC.Core.Continuations;
    using FubuPageExtensionsRecipe.Web.Handlers.Home;

    public class PostHandler
    {
        public FubuContinuation Execute(CreateRequestModel model)
        {
            return FubuContinuation.RedirectTo<Home.GetHandler>(x => x.Execute());
        }
    }
}