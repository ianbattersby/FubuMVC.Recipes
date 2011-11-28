namespace CustomAuthorizationPolicy.Tests.Unit.Handlers.Account.LogOn
{
    using System;
    using NUnit.Framework;
    using LogOn = CustomAuthorizationPolicy.Web.Handlers.Account.LogOn;

    [TestFixture]
    public class GetHandlerTests
    {
        [Test]
        public void when_calling_execute_return_is_not_null()
        {
            var handler = new LogOn.GetHandler();
            Assert.IsNotNull(handler.Execute());
        }
    }
}
