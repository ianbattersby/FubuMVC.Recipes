namespace ICurrentChainRecipe.Tests.Unit.Handlers.DeadEnd
{
    using System;
    using FubuMVC.Core.Http;
    using Moq;
    using NUnit.Framework;
    using Home = ICurrentChainRecipe.Web.Handlers.Home;

    [TestFixture]
    public class GetHandlerTests
    {
        private Mock<ICurrentChain> currentChainMock;
        private Home.GetHandler handler;

        [SetUp]
        public void test_setup()
        {
            currentChainMock = new Mock<ICurrentChain>();
            currentChainMock.SetupAllProperties();

            handler = new Home.GetHandler(currentChainMock.Object);
        }

        [Test]
        public void when_calling_execute_return_is_not_null()
        {
            var result = handler.Execute();
            Assert.IsNotNull(result);
        }
    }
}
