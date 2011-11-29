namespace FubuPageExtensionsRecipe.Web
{
    using System;
    using FubuMVC.Core;
    using FubuMVC.Spark;
    using FubuPageExtensionsRecipe.Web.Handlers;
    using Home = FubuPageExtensionsRecipe.Web.Handlers.Home;
    using FubuPageExtensionsRecipe.Web.Conventions;

    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            // This line turns on the basic diagnostics and request tracing
            IncludeDiagnostics(true);

            // Let's use handler convention
            ApplyHandlerConventions<HandlersMarker>();

            // Where is our home page?
            Routes.HomeIs<Home.GetHandler>(x => x.Execute());

            // Using Spark as it's great!
            this.UseSpark();

            // Some fancy HTML conventions
            this.HtmlConvention<RecipeHtmlConventionsRegistry>();

            // Match views to action methods by matching
            // on model type, view name, and namespace
            Views.TryToAttachWithDefaultConventions();
        }
    }
}