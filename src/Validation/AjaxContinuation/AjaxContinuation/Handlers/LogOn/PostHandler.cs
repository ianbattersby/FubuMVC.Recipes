namespace AjaxContinuation.Handlers.LogOn
{
    public class PostHandler
    {
        public FubuMVC.Core.Ajax.AjaxContinuation Execute(LogOnInputModel input)
        {
            return new FubuMVC.Core.Ajax.AjaxContinuation
            {
                Success = true
            };
        }
    }
}