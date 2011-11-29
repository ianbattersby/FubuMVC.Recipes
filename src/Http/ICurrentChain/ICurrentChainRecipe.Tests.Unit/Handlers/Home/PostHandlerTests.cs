namespace ICurrentChainRecipe.Tests.Unit.Handlers.Home
{
    using System;
    using Home = ICurrentChainRecipe.Web.Handlers.Home;
    using DeadEnd = ICurrentChainRecipe.Web.Handlers.DeadEnd;
    using NUnit.Framework;

    [TestFixture]
    public class PostHandlerTests
    {
        private Home.PostHandler handler;

        [SetUp]
        public void test_setup()
        {
            this.handler = new Home.PostHandler();
        }

        [Test]
        public void when_calling_execute_redirects_to_deadend_handler()
        {
            var result = this.handler.Execute(new Home.HomeRequestModel());
            result.AssertWasRedirectedTo<DeadEnd.GetHandler>(x => x.Execute());
        }
    }
}
