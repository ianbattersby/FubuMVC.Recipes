namespace IAuthorizationPolicyRecipe.Tests.Unit.Handlers.AdvSectionOne
{
    using System;
    using NUnit.Framework;
    using AdvSectionOne = IAuthorizationPolicyRecipe.Web.Handlers.AdvSectionOne;

    [TestFixture]
    public class GetHandlerTests
    {
        [Test]
        public void when_calling_execute_return_is_not_null()
        {
            var handler = new AdvSectionOne.GetHandler();
            Assert.IsNotNull(handler.Execute());
        }
    }
}
