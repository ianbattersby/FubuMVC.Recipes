namespace IRedirectableRecipe.Tests.Unit.Handlers.Home
{
    using System;
    using Home = IRedirectableRecipe.Web.Handlers.Home;
    using DeadEnd = IRedirectableRecipe.Web.Handlers.DeadEnd;
    using NUnit.Framework;

    [TestFixture]
    public class PostHandlerTests
    {
        private Home.PostHandler handler;

        [SetUp]
        public void test_setup()
        {
            this.handler = new Home.PostHandler();
        }

        [Test]
        public void when_calling_execute_without_redirectconfirmation_continues_to_home_get_hander()
        {
            var result = this.handler.Execute(
                new Home.HomeRequestModel()
                {
                    RedirectConfirmation = String.Empty
                });

            Assert.IsNull(result.RedirectTo);
        }

        [Test]
        public void when_calling_execute_with_redirectconfirmation_continues_to_deadend_handler()
        {
            var result = this.handler.Execute(
                new Home.HomeRequestModel()
                {
                    RedirectConfirmation = Home.PostHandler.RedirectConfirm.ToUpper()
                });

            Assert.IsNotNull(result.RedirectTo);
            result.RedirectTo.AssertWasRedirectedTo<DeadEnd.GetHandler>(x => x.Execute(new DeadEnd.DeadEndViewModel()));
        }

        [Test]
        public void when_calling_excute_with_redirectconfirmation_inmixedcase_continues_to_deadend_handler()
        {
            var result = this.handler.Execute(
                new Home.HomeRequestModel()
                {
                    RedirectConfirmation = Home.PostHandler.RedirectConfirm.ToLower()
                });

            Assert.IsNotNull(result.RedirectTo);
            result.RedirectTo.AssertWasRedirectedTo<DeadEnd.GetHandler>(x => x.Execute(new DeadEnd.DeadEndViewModel()));
        }
    }
}
