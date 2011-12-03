namespace IUrlRegistryRecipe.Web.Models.Books
{
    using System;

    public class BookFindRequestModel
    {
        public BookFindRequestModel()
        {
        }

        public BookFindRequestModel(
            Guid id,
            string title,
            string author)
        {
            this.FindById = id;
            this.FindByTitle = title;
            this.FindByAuthor = author;
        }

        public Guid FindById { get; private set; }
        public string FindByTitle { get; private set; }
        public string FindByAuthor { get; private set; }
    }
}