namespace DownloadStreamRecipe
{
    using DownloadStreamRecipe.Controllers;
    using FubuMVC.Core;
    using FubuMVC.Core.Registration.Conventions;

    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            // This line turns on the basic diagnostics and request tracing
            IncludeDiagnostics(true);

            ApplyConvention<DownloadFileConvention>();

            // All public methods from concrete classes ending in "Controller"
            // in this assembly are assumed to be action methods
            Actions.IncludeClassesSuffixedWithController();

            // Policies
            Routes
                .HomeIs<HomeController>(home => home.Index())
                .IgnoreControllerNamespaceEntirely()
                .IgnoreMethodSuffix("Html")
                .RootAtAssemblyNamespace();

            // Match views to action methods by matching
            // on model type, view name, and namespace
            Views.TryToAttachWithDefaultConventions();
        }
    }
}