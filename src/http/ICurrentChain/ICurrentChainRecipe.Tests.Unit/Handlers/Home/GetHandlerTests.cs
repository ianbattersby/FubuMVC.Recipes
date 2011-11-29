namespace ICurrentChainRecipe.Tests.Unit.Handlers.Home
{
    using System;
    using FubuMVC.Core.Http;
    using Moq;
    using NUnit.Framework;
    using DeadEnd = ICurrentChainRecipe.Web.Handlers.DeadEnd;

    [TestFixture]
    public class GetHandlerTests
    {
        private Mock<ICurrentChain> currentChainMock;
        private DeadEnd.GetHandler handler;

        [SetUp]
        public void test_setup()
        {
            currentChainMock = new Mock<ICurrentChain>();
            currentChainMock.SetupAllProperties();

            handler = new DeadEnd.GetHandler(currentChainMock.Object);
        }

        [Test]
        public void when_calling_execute_return_is_not_null()
        {
            var result = handler.Execute();
            Assert.IsNotNull(result);
        }
    }
}
