namespace IUrlRegistryRecipe.Web.Models
{
    using System;
    using System.Collections.Generic;
    using FubuMVC.Core.Urls;

    public class HomeViewModel
    {
        public HomeViewModel()
        {
        }

        public HomeViewModel(IEnumerable<CallList> callLists)
        {
            this.CallLists = callLists;
        }
       
        public IEnumerable<CallList> CallLists {get;private set;}
    }
}