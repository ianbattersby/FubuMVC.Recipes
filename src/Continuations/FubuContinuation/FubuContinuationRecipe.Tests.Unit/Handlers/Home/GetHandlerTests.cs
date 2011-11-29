namespace FubuContinuationRecipe.Tests.Unit.Handlers.Home
{
    using System;
    using NUnit.Framework;
    using Home = FubuContinuationRecipe.Web.Handlers.Home;

    [TestFixture]
    public class GetHandlerTests
    {
        [Test]
        public void when_calling_execute_return_is_not_null()
        {
            var handler = new Home.GetHandler();
            Assert.IsNotNull(handler.Execute());
        }
    }
}
