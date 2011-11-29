namespace ICurrentChainRecipe.Web.Helpers
{
    using System;
    using FubuMVC.Core.Registration.Nodes;
    using ICurrentChainRecipe.Web.Handlers;

    public static class ViewModelHelper
    {
        public static void PopulateModelWithChain(BehaviorChain chain, CommonViewModel model)
        {
            model.Id = chain.UniqueId.ToString();
            model.RouteDefinition = chain.Route.ToString();

            foreach (var call in chain.Calls)
            {
                model.Calls.Add(call.ToString());
            }

            foreach (var output in chain.Outputs)
            {
                model.Outputs.Add(output.ToString());
            }

            foreach (var filter in chain.Filters)
            {
                model.Filters.Add(filter.ToString());
            }
        }
    }
}