namespace ICurrentChainRecipe.Web
{
    using FubuMVC.Core;
    using FubuMVC.Spark;
    using ICurrentChainRecipe.Web.Handlers;
    using Home = Handlers.Home;

    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            // This line turns on the basic diagnostics and request tracing
            IncludeDiagnostics(true);

            // Let's use the handlers convention
            ApplyHandlerConventions<HandlersMarker>();

            // Set the home/default page
            Routes.HomeIs<Home.GetHandler>(x => x.Execute());

            // Let's use Spark view engine
            this.UseSpark();

            // Match views to action methods by matching
            // on model type, view name, and namespace
            Views.TryToAttachWithDefaultConventions();
        }
    }
}