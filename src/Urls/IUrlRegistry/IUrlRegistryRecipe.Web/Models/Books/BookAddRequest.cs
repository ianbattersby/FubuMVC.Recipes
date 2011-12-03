namespace IUrlRegistryRecipe.Web.Models.Books
{
    using System;

    public class BookAddRequest
    {
        public BookAddRequest()
        {
        }

        public BookAddRequest(
            string title,
            string author,
            DateTime published,
            double price)
        {
            this.Title = title;
            this.Author = author;
            this.Published = published;
            this.Price = price;
        }
        
        public string Title { get; private set; }
        public string Author { get; private set; }
        public DateTime Published { get; private set; }
        public double Price { get; private set; }
    }
}
