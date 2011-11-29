namespace IRedirectableRecipe.Web
{
    using FubuMVC.Core;
    using FubuMVC.Spark;
    using IRedirectableRecipe.Web.Handlers;
    using Home = IRedirectableRecipe.Web.Handlers.Home;

    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            // This line turns on the basic diagnostics and request tracing
            IncludeDiagnostics(true);

            // Let's use the handlers convention, it rocks
            ApplyHandlerConventions<HandlersMarker>();

            // Where is home
            Routes.HomeIs<Home.GetHandler>(x => x.Execute());
            
            // Engage Spark
            this.UseSpark();

            // Match views to action methods by matching
            // on model type, view name, and namespace
            Views.TryToAttachWithDefaultConventions();
        }
    }
}