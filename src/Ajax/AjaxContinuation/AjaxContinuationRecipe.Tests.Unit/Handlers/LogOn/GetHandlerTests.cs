namespace AjaxContinuationRecipe.Tests.Unit.Handlers.LogOn
{
    using System;
    using NUnit.Framework;
    using AjaxContinuationRecipe.Handlers.LogOn;

    [TestFixture]
    public class GetHandlerTests
    {
        private GetHandler getHandler;

        [SetUp]
        public void TestSetup()
        {
            this.getHandler = new GetHandler();
        }

        [Test]
        public void CallingExecuteReturnsNotNullLogOnRequestModel()
        {
            var result = this.getHandler.Execute();
            Assert.IsNotNull(result);
        }
    }
}