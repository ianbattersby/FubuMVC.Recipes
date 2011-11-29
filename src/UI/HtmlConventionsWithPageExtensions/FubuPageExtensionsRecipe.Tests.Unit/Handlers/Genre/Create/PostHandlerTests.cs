namespace FubuPageExtensionsRecipe.Tests.Unit.Handlers.Genre.Create
{
    using System;
    using NUnit.Framework;
    using GenreCreate = FubuPageExtensionsRecipe.Web.Handlers.Genre.Create;

    [TestFixture]
    public class PostHandlerTests
    {
        [Test]
        public void when_calling_execute_return_is_not_null()
        {
            var handler = new GenreCreate.PostHandler();
            Assert.IsNotNull(handler.Execute(new GenreCreate.CreateRequestModel()));
        }

        [Test]
        public void when_calling_execute_returns_valid_guid()
        {
            Guid guidResult;

            var handler = new GenreCreate.PostHandler();
            var result = handler.Execute(new GenreCreate.CreateRequestModel());
            
            Assert.IsTrue(Guid.TryParse(result, out guidResult));
        }
    }
}
