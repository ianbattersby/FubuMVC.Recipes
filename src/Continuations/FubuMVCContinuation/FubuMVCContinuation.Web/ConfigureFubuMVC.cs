namespace FubuMVCContinuation.Web
{
    using FubuMVC.Core;
    using FubuMVC.Spark;
    using FubuMVCContinuation.Web.Handlers;
    using Home = Handlers.Home;

    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            // This line turns on the basic diagnostics and request tracing
            IncludeDiagnostics(true);

            // We're going to use the handlers convention for this recipe
            ApplyHandlerConventions<HandlersMarker>();

            // We all need a home
            Routes.HomeIs<Home.GetHandler>(x => x.Execute());

            // We're using Spark, 'cause it's ace!
            this.UseSpark();

            // Match views to action methods by matching
            // on model type, view name, and namespace
            Views.TryToAttachWithDefaultConventions();
        }
    }
}