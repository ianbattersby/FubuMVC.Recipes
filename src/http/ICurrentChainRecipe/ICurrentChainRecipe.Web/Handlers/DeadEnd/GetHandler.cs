namespace ICurrentChainRecipe.Web.Handlers.DeadEnd
{
    using System.Collections.Generic;
    using FubuMVC.Core.Http;
    using ICurrentChainRecipe.Web.Helpers;

    public class GetHandler
    {
        ICurrentChain currentChain;

        public GetHandler(ICurrentChain currentChain)
        {
            this.currentChain = currentChain;
        }

        public DeadEndViewModel Execute()
        {
            var model = new DeadEndViewModel()
            {
                Calls = new List<string>(),
                Outputs = new List<string>(),
                Filters = new List<string>()
            };

            if (currentChain.Current != null)
            {
                ViewModelHelper.PopulateModelWithChain(currentChain.Current, model);
            }

            return model;
        }
    }
}