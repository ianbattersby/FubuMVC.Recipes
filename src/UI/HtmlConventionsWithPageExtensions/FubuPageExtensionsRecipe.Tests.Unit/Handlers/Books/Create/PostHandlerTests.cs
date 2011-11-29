namespace FubuPageExtensionsRecipe.Tests.Unit.Handlers.Books.Create
{
    using System;
    using NUnit.Framework;
    using BooksCreate = FubuPageExtensionsRecipe.Web.Handlers.Books.Create;
    using Home = FubuPageExtensionsRecipe.Web.Handlers.Home;

    [TestFixture]
    public class PostHandlerTests
    {
        [Test]
        public void when_calling_execute_return_is_not_null()
        {
            var handler = new BooksCreate.PostHandler();
            Assert.IsNotNull(handler.Execute(new BooksCreate.CreateRequestModel()));
        }

        [Test]
        public void when_calling_execute_returns_continuation_to_home()
        {
            var handler = new BooksCreate.PostHandler();
            var result = handler.Execute(new BooksCreate.CreateRequestModel());

            result.AssertWasRedirectedTo<Home.GetHandler>(x => x.Execute());
        }
    }
}
