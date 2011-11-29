namespace IAuthorizationPolicyRecipe.Web
{
    using FubuMVC.Core;
    using FubuMVC.Spark;
    using Handlers;
    using Security;
    using Home = Handlers.Home;

    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            // This line turns on the basic diagnostics and request tracing
            IncludeDiagnostics(true);

            // Apply handler convention for EndPoints in HandlersMarker namespace root
            ApplyHandlerConventions<HandlersMarker>();

            // Let's add out custom security policy
            Policies.Add<AccessGroupConvention>();

            // Set the home page
            Routes.HomeIs<Home.GetHandler>(x=>x.Execute());

            // Let's use the wonderful Spark
            this.UseSpark();

            // Match views to action methods by matching
            // on model type, view name, and namespace
            Views.TryToAttachWithDefaultConventions();
        }
    }
}