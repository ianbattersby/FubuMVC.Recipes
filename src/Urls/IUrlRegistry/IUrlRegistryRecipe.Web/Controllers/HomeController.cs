namespace IUrlRegistryRecipe.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using FubuMVC.Core.Urls;
    using Models;
    using Models.Books;

    public class HomeController
    {
        public HomeViewModel Home()
        {
            var urlForOMI = new CallList("If our action is employing OMIOMO (One Model In, One Model Out) we can derive a Url based on that input model.");
            urlForOMI.Calls.Add(x => x.UrlFor(new BookFindRequestModel()));
            urlForOMI.Calls.Add(x => x.UrlFor<BookFindRequestModel>());

            var urlForZMI = new CallList("Alternatively we can derive Urls based on the action name, especially useful if no input model is being used (ZMIOMO - Zero Model In, One Model Out).");
            urlForZMI.Calls.Add(x => x.UrlFor<BookController>(a => a.FindBook(new BookFindRequestModel())));

            return new HomeViewModel(
                new List<CallList>() {
                    urlForOMI,
                    urlForZMI
                });
        }
    }
}