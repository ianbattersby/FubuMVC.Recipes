namespace AjaxContinuation.Tests.Unit.Handlers.LogOn
{
    using System;
    using NUnit.Framework;
    using AjaxContinuation.Handlers.LogOn;

    [TestFixture]
    public class PostHandlerTests
    {
        private PostHandler postHandler;

        [SetUp]
        public void TestSetup()
        {
            this.postHandler = new PostHandler();
        }

        [Test]
        public void WhenCallingExecuteReturnsNotNullAjaxContinuation()
        {
            var result = this.postHandler.Execute(new LogOnInputModel() { UserName = "TestUser", Password = "TestPassword" });
            Assert.IsNotNull(result);
        }
    }
}