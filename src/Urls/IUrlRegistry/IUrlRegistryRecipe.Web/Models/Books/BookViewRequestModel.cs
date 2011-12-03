namespace IUrlRegistryRecipe.Web.Models.Books
{
    using System;

    public class BookViewRequestModel
    {
        public BookViewRequestModel(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; private set; }
    }
}