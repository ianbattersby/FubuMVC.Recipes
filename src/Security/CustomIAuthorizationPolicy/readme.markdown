
Custom IAuthorizationPolicy Recipe
==
This recipe shows how you can implement a completely custom authorization policy based on the HandlersConvention HTTP handler classes. Particularly interesting here is using an IConfigurationAction to apply the policy conditionally and with a generic type.

**NOTE!**
FubuMVC has it's own group-access authorization policy built-in, you may wish to check this out first if you're looking for an out-of-the-box solution.