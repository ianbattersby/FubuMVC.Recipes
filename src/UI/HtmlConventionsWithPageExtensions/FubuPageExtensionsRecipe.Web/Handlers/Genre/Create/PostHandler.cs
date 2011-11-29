namespace FubuPageExtensionsRecipe.Web.Handlers.Genre.Create
{
    using System;

    public class PostHandler
    {
        public string Execute(CreateRequestModel model)
        {
            return Guid.NewGuid().ToString();
        }
    }
}