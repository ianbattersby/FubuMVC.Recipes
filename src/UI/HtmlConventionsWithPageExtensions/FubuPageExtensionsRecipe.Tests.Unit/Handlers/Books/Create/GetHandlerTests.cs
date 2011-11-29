namespace FubuPageExtensionsRecipe.Tests.Unit.Handlers.Books.Create
{
    using System;
    using NUnit.Framework;
    using BooksCreate = FubuPageExtensionsRecipe.Web.Handlers.Books.Create;

    [TestFixture]
    public class GetHandlerTests
    {
        [Test]
        public void when_calling_execute_return_is_not_null()
        {
            var handler = new BooksCreate.GetHandler();
            Assert.IsNotNull(handler.Execute());
        }
    }
}
