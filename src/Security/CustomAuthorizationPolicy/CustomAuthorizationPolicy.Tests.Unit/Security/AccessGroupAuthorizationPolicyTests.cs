namespace CustomAuthorizationPolicy.Tests.Unit.Security
{
    using System;
    using System.Collections.Generic;
    using System.Security.Principal;
    using CustomAuthorizationPolicy.Web.Security;
    using FubuMVC.Core.Runtime;
    using FubuMVC.Core.Security;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class AccessGroupAuthorizationPolicyTests
    {
        private readonly IUserData userData = new UserData(
            new Dictionary<string, IEnumerable<string>>()
            {
                {"NoLevelUser", new string[0] },
                {"LevelOneUser", new string[] { TestAttributeReference.LevelOne } },
                {"LevelTwoUser", new string[] { TestAttributeReference.LevelOne, TestAttributeReference.LevelTwo } },
            });

        private Mock<ISecurityContext> securityContextMock;
        private Mock<IPrincipal> principalMock;
        private Mock<IIdentity> identityMock;
        private Mock<IFubuRequest> fubuRequestMock;

        [SetUp]
        public void test_setup()
        {
            securityContextMock = new Mock<ISecurityContext>();
            principalMock = new Mock<IPrincipal>();
            identityMock = new Mock<IIdentity>();
            fubuRequestMock = new Mock<IFubuRequest>();

            securityContextMock.SetupGet(x => x.CurrentUser).Returns((IPrincipal)null);
            principalMock.SetupGet(x => x.Identity).Returns((IIdentity)null);
        }

        [Test]
        public void given_nosession_and_no_attribute_returns_deny()
        {
            var policy = new AccessGroupAuthorizationPolicy<TestGetHandlerWithNoAttribute>(
                securityContextMock.Object,
                userData);

            Assert.AreEqual(
                AuthorizationRight.Deny,
                policy.RightsFor(fubuRequestMock.Object));
        }

        [Test]
        public void given_validsession_and_no_attribute_returns_deny()
        {
            SetupValidSession("NoLevelUser");

            var policy = new AccessGroupAuthorizationPolicy<TestGetHandlerWithNoAttribute>(
                securityContextMock.Object,
                userData);

            Assert.AreEqual(
                AuthorizationRight.Deny,
                policy.RightsFor(fubuRequestMock.Object));
        }

        [Test]
        public void given_nosession_and_nogroupstomatch_returns_allow()
        {
            var policy = new AccessGroupAuthorizationPolicy<TestGetHandlerWithEmptyAttribute>(
                securityContextMock.Object,
                userData);

            Assert.AreEqual(
                AuthorizationRight.Allow,
                policy.RightsFor(fubuRequestMock.Object));
        }

        [Test]
        public void given_session_and_nogroupstomatch_returns_allow()
        {
            SetupValidSession("NoLevelUser");

            var policy = new AccessGroupAuthorizationPolicy<TestGetHandlerWithEmptyAttribute>(
                securityContextMock.Object,
                userData);

            Assert.AreEqual(
                AuthorizationRight.Allow,
                policy.RightsFor(fubuRequestMock.Object));
        }

        [Test]
        public void given_validsession_and_oneandonly_matching_attribute_returns_allow()
        {
            SetupValidSession("LevelOneUser");

            var policy = new AccessGroupAuthorizationPolicy<TestGetHandlerWithLevelOneAttribute>(
                securityContextMock.Object,
                userData);

            Assert.AreEqual(
                AuthorizationRight.Allow,
                policy.RightsFor(fubuRequestMock.Object));
        }

        [Test]
        public void given_validsession_and_oneoutoftwo_matching_attributes_returns_deny()
        {
            SetupValidSession("LevelOneUser");

            var policy = new AccessGroupAuthorizationPolicy<TestGetHandlerWithLevelOneAndTwoAttributes>(
                securityContextMock.Object,
                userData);

            Assert.AreEqual(
                AuthorizationRight.Deny,
                policy.RightsFor(fubuRequestMock.Object));
        }

        [Test]
        public void given_validsession_and_twooutoftwo_matching_attributes_returns_allow()
        {
            SetupValidSession("LevelTwoUser");

            var policy = new AccessGroupAuthorizationPolicy<TestGetHandlerWithLevelOneAndTwoAttributes>(
                securityContextMock.Object,
                userData);

            Assert.AreEqual(
                AuthorizationRight.Allow,
                policy.RightsFor(fubuRequestMock.Object));
        }

        [Test]
        public void given_validsession_and_unknown_user_returns_denied()
        {
            SetupValidSession("UserDoesNotExist");

            var policy = new AccessGroupAuthorizationPolicy<TestGetHandlerWithLevelOneAndTwoAttributes>(
                securityContextMock.Object,
                userData);

            Assert.AreEqual(
                AuthorizationRight.Deny,
                policy.RightsFor(fubuRequestMock.Object));
        }

        private void SetupValidSession(string user)
        {
            securityContextMock.SetupGet(x => x.CurrentUser).Returns(principalMock.Object);
            principalMock.SetupGet(x => x.Identity).Returns(identityMock.Object);

            identityMock.SetupGet(x => x.AuthenticationType).Returns(@"Cookie");
            identityMock.SetupGet(x => x.IsAuthenticated).Returns(true);
            identityMock.SetupGet(x => x.Name).Returns(user);
        }
    }

    #region Here be dragons (not really - just test data ;)
    public static class TestAttributeReference
    {
        public const string LevelOne = "LevelOne";
        public const string LevelTwo = "LevelTwo";
    }

    public class TestGetHandlerWithNoAttribute
    {
        public void Execute() { }
    }

    [AccessGroup]
    public class TestGetHandlerWithEmptyAttribute
    {
        public void Execute() { }
    }

    [AccessGroup(TestAttributeReference.LevelOne)]
    public class TestGetHandlerWithLevelOneAttribute
    {
        public void Execute() { }
    }

    [AccessGroup(TestAttributeReference.LevelOne, TestAttributeReference.LevelTwo)]
    public class TestGetHandlerWithLevelOneAndTwoAttributes
    {
        public void Execute() { }
    }
    #endregion
}
