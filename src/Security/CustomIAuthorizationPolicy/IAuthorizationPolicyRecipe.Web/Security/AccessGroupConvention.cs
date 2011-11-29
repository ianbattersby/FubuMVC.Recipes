namespace IAuthorizationPolicyRecipe.Web.Security
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FubuMVC.Core.Registration;

    public class AccessGroupConvention : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            graph
                .Actions()
                .Where(action => !action.HandlerType.Namespace.StartsWith("FubuMVC.")) // Don't want this to apply to adv diagnostics!
                .Each(action => action
                    .ParentChain()
                    .Authorization
                    .AddPolicy(typeof(AccessGroupAuthorizationPolicy<>).MakeGenericType(action.HandlerType)));
        }
    }
}