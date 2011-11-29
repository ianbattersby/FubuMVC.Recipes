namespace FubuPageExtensionsRecipe.Web.Handlers.Books.Create
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using FubuPageExtensionsRecipe.Web.Models;

    public class CreateRequestModel
    {
        public String Title { get; set; }

        public String Genre { get; set; }

        public String Description_BigText { get; set; }

        public BookStatus BookStatus { get; set; }

        public IList<string> Authors { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}