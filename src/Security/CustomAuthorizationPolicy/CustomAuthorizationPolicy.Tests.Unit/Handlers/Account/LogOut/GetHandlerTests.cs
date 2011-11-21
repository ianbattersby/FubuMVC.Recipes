namespace CustomAuthorizationPolicy.Tests.Unit.Handlers.Account.LogOut
{
    using System;
    using CustomAuthorizationPolicy.Web.Security;
    using Moq;
    using NUnit.Framework;
    using LogOn = CustomAuthorizationPolicy.Web.Handlers.Account.LogOn;
    using LogOut = CustomAuthorizationPolicy.Web.Handlers.Account.LogOut;

    [TestFixture]
    public class GetHandlerTests
    {
        private LogOut.GetHandler handler;
        private Mock<IFormsAuthenticationWrapper> formsAuthenticationMock;

        [SetUp]
        public void test_setup()
        {
            this.formsAuthenticationMock = new Mock<IFormsAuthenticationWrapper>();
            this.formsAuthenticationMock.Setup(x => x.SignOut());

            this.handler = new LogOut.GetHandler(formsAuthenticationMock.Object);
        }

        [Test]
        public void when_calling_execute_calls_formsauth()
        {
            var result = handler.Execute();
            formsAuthenticationMock.Verify(x => x.SignOut(), Times.Once());
        }

        [Test]
        public void when_calling_execute_returns_fubucontinuation()
        {
            var result = handler.Execute();
            result.AssertWasRedirectedTo<LogOn.GetHandler>(x=>x.Execute());
        }
    }
}
