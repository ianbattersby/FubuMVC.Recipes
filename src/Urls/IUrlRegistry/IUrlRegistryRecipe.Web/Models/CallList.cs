namespace IUrlRegistryRecipe.Web.Models
{
    using System;
    using System.Collections.Generic;
    using FubuMVC.Core.Urls;

    public class CallList
    {
        public CallList(string htmlDescription)
        {
            this.HtmlDescription = htmlDescription;
            this.Calls = new DynamicFuncList<IUrlRegistry>();
        }

        public string HtmlDescription { get; private set; }
        public DynamicFuncList<IUrlRegistry> Calls { get; set; }
    }
}