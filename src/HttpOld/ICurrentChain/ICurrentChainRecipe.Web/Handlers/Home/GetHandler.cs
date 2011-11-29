namespace ICurrentChainRecipe.Web.Handlers.Home
{
    using System;
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

        public HomeViewModel Execute()
        {
            var homeModel = new HomeViewModel()
            {
                Calls = new List<string>(),
                Outputs = new List<string>(),
                Filters = new List<string>()
            };

            if (currentChain.Current != null)
            {
                ViewModelHelper.PopulateModelWithChain(currentChain.Current, homeModel);
            }

            return homeModel;
        }
    }
}