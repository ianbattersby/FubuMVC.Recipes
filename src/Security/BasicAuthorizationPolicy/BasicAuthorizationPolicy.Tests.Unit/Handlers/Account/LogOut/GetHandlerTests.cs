namespace BasicAuthorizationPolicy.Tests.Unit.Handlers.Account.LogOut
{
    using System;
    using FubuMVC.Core.Security;
    using Moq;
    using NUnit.Framework;
    using LogOn = BasicAuthorizationPolicy.Web.Handlers.Account.LogOn;
    using LogOut = BasicAuthorizationPolicy.Web.Handlers.Account.LogOut;
 
    [TestFixture]
    public class GetHandlerTests
    {
        private LogOut.GetHandler handler;
        private Mock<IAuthenticationContext> authContextMock;

        [SetUp]
        public void test_setup()
        {
            this.authContextMock = new Mock<IAuthenticationContext>();
            this.authContextMock.Setup(x => x.SignOut());

            this.handler = new LogOut.GetHandler(authContextMock.Object);
        }

        [Test]
        public void when_calling_execute_calls_authcontext()
        {
            var result = handler.Execute(new LogOut.LogOutRequestModel());
            authContextMock.Verify(x => x.SignOut(), Times.Once());
        }

        [Test]
        public void when_calling_execute_returns_fubucontinuation()
        {
            var result = handler.Execute(new LogOut.LogOutRequestModel());
            result.AssertWasRedirectedTo<LogOn.GetHandler>(x=>x.Execute());
        }
    }
}
