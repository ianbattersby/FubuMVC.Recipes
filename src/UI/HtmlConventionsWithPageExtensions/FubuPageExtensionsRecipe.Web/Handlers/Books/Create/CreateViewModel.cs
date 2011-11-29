namespace FubuPageExtensionsRecipe.Web.Handlers.Books.Create
{
    using System;
    using System.Collections.Generic;

    public class CreateViewModel : CreateRequestModel
    {
        public CreateViewModel()
		{
            this.Genres = new Dictionary<string, string>()
                {
                    { Guid.NewGuid().ToString(), "Fiction" },
                    { Guid.NewGuid().ToString(), "Crime" },
                    { Guid.NewGuid().ToString(), "Biography" },
                    { Guid.NewGuid().ToString(), "History" },
                };
		}

		public IDictionary<string, string> Genres { get; private set; }
    }
}