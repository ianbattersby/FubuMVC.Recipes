namespace IUrlRegistryRecipe.Web.Controllers
{
    using System;
    using FubuMVC.Core.Continuations;
    using Models.Books;

    public class BookController
    {
        public BookViewModel ViewBook(BookViewRequestModel model)
        {
            Guid id = model.Id;

            // Find book details by Id

            return new BookViewModel(
                id,
                "Book Title",
                "Ian Battersby",
                DateTime.Now,
                23.99);
        }

        public FubuContinuation FindBook(BookFindRequestModel model)
        {
            Guid id;

            if (model.FindById != null)
            {
                id = model.FindById;
            }
            else
            {
                // Find book id
                id = Guid.NewGuid();
            }

            return FubuContinuation.RedirectTo<BookController>(x => x.ViewBook(new BookViewRequestModel(id)));
        }

        public FubuContinuation AddBook(BookAddRequest model)
        {
            Guid id = Guid.NewGuid();

            return FubuContinuation.RedirectTo<BookController>(x => x.ViewBook(new BookViewRequestModel(id)));
        }
    }
}