namespace ICurrentChainRecipe.Web.Handlers
{
    using System.Collections.Generic;

    public class CommonViewModel
    {
        public string Id { get; set; }
        public string RouteDefinition { get; set; }
        public IList<string> Calls { get; set; }
        public IList<string> Outputs { get; set; }
        public IList<string> Filters { get; set; }
    }
}