namespace IAuthorizationPolicyRecipe.Tests.Unit.Handlers.Account.LogOn
{
    using System;
    using IAuthorizationPolicyRecipe.Web.Security;
    using Moq;
    using NUnit.Framework;
    using Home = IAuthorizationPolicyRecipe.Web.Handlers.Home;
    using LogOn = IAuthorizationPolicyRecipe.Web.Handlers.Account.LogOn;

    [TestFixture]
    public class PostHandlerTests
    {
        private LogOn.PostHandler postHandler;
        private Mock<IFormsAuthenticationWrapper> formsAuthenticationMock;

        [SetUp]
        public void test_setup()
        {
            this.formsAuthenticationMock = new Mock<IFormsAuthenticationWrapper>();
            this.formsAuthenticationMock.Setup(x => x.SetAuthCookie(It.IsAny<string>(), It.IsAny<bool>()));

            this.postHandler = new LogOn.PostHandler(formsAuthenticationMock.Object);
        }

        [Test]
        public void logging_on_with_invalid_details_redirects_back_to_logon()
        {
            var result = this.postHandler.Execute(
                new LogOn.LogOnRequestModel()
                {
                    Name = "",
                    Password = ""
                });

            result.AssertWasRedirectedTo<LogOn.GetHandler>(x => x.Execute());
        }

        [Test]
        public void logging_on_with_invalid_details_does_not_call_formsauth()
        {
            var result = this.postHandler.Execute(
                new LogOn.LogOnRequestModel()
                {
                    Name = "",
                    Password = ""
                });

            formsAuthenticationMock.Verify(x => x
                .SetAuthCookie(It.IsAny<string>(), It.IsAny<bool>()),
                Times.Never());
        }

        [Test]
        public void logging_on_with_valid_details_redirects_to_home()
        {
            var result = this.postHandler.Execute(
                new LogOn.LogOnRequestModel()
                {
                    Name = "TestUser",
                    Password = "TestPassword"
                });

            result.AssertWasRedirectedTo<Home.GetHandler>(x => x.Execute());
        }

        [Test]
        public void logging_on_with_valid_details_does_call_formsauth()
        {
            var result = this.postHandler.Execute(
                new LogOn.LogOnRequestModel()
                {
                    Name = "TestUser",
                    Password = "TestPassword"
                });

            formsAuthenticationMock.Verify(x => x
                .SetAuthCookie(It.IsAny<string>(), It.IsAny<bool>()),
                Times.Once());
        }
    }
}
