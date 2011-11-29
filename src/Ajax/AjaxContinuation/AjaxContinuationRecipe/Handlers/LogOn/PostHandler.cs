namespace AjaxContinuationRecipe.Handlers.LogOn
{
    using FubuMVC.Core.Ajax;

    public class PostHandler
    {
        public AjaxContinuation Execute(LogOnInputModel input)
        {
            return new AjaxContinuation
            {
                Success = true
            };
        }
    }
}