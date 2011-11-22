namespace BasicAuthorizationPolicy.Tests.Unit.Handlers.Account.LogOn
{
    using System;
    using System.Collections.Generic;
    using BasicAuthorizationPolicy.Web.Security;
    using Moq;
    using NUnit.Framework;
    using Home = BasicAuthorizationPolicy.Web.Handlers.Home;
    using LogOn = BasicAuthorizationPolicy.Web.Handlers.Account.LogOn;
    using FubuMVC.Core.Security;

    [TestFixture]
    public class PostHandlerTests
    {
        private readonly IUserData userData = new UserData(
            new Dictionary<string, IEnumerable<string>>()
            {
                {"NoLevelUser", new string[0] },
                {"LevelOneUser", new string[] { TestAttributeReference.LevelOne } },
                {"LevelTwoUser", new string[] { TestAttributeReference.LevelOne, TestAttributeReference.LevelTwo } },
            });

        private Mock<IAuthenticationContext> authContextMock;
        private LogOn.PostHandler postHandler;

        [SetUp]
        public void test_setup()
        {
            this.authContextMock = new Mock<IAuthenticationContext>();
            this.authContextMock.Setup(x => x.ThisUserHasBeenAuthenticated(It.IsAny<string>(), It.IsAny<bool>()));

            this.postHandler = new LogOn.PostHandler(authContextMock.Object, userData);
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
        public void logging_on_with_invalid_details_does_not_call_authcontext()
        {
            var result = this.postHandler.Execute(
                new LogOn.LogOnRequestModel()
                {
                    Name = "",
                    Password = ""
                });

            authContextMock.Verify(x => x
                .ThisUserHasBeenAuthenticated(It.IsAny<string>(), It.IsAny<bool>()),
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
        public void logging_on_with_valid_details_calls_authcontext()
        {
            var result = this.postHandler.Execute(
                new LogOn.LogOnRequestModel()
                {
                    Name = "TestUser",
                    Password = "TestPassword"
                });

            authContextMock.Verify(x => x
                .ThisUserHasBeenAuthenticated(It.IsAny<string>(), It.IsAny<bool>()),
                Times.Once());
        }
    }

    #region Here be dragons (not really - just test data ;)
    public static class TestAttributeReference
    {
        public const string LevelOne = "LevelOne";
        public const string LevelTwo = "LevelTwo";
    }
    #endregion
}
