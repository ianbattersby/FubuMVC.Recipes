namespace IUrlRegistryRecipe.Web.Models.Books
{
    using System;

    public class BookViewModel : BookAddRequest
    {
        public BookViewModel()
        {
        }

        public BookViewModel(
            Guid Id,
            string title,
            string author,
            DateTime published,
            double price) : base (title, author, published, price)
        {
            this.Id = Id;
        }

        public Guid Id { get; private set; }
    }
}