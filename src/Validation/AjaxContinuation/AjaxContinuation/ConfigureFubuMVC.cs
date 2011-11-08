using FubuMVC.Core;
using FubuMVC.Spark;
using FubuMVC.Validation;

namespace AjaxContinuation
{
    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            // This line turns on the basic diagnostics and request tracing
            IncludeDiagnostics(true);

            ApplyHandlerConventions<Handlers.HandlersMarker>();

            Routes.HomeIs<Handlers.LogOn.GetHandler>(home => home.Execute());

            // All public methods from concrete classes ending in "Controller"
            // in this assembly are assumed to be action methods
            Actions.IncludeClassesSuffixedWithController();

            this.UseSpark();

            this.Validation();

            // Policies
            Routes
                .IgnoreControllerNamesEntirely()
                .IgnoreMethodSuffix("Html")
                .RootAtAssemblyNamespace();

            // Match views to action methods by matching
            // on model type, view name, and namespace
            Views.TryToAttachWithDefaultConventions();
        }
    }
}