namespace FubuMVCContinuation.Tests.Unit.Handlers.Home
{
    using System;
    using Home = FubuMVCContinuation.Web.Handlers.Home;
    using DeadEnd = FubuMVCContinuation.Web.Handlers.DeadEnd;
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

            result.AssertWasRedirectedTo<Home.GetHandler>(x => x.Execute());
        }

        [Test]
        public void when_calling_execute_with_redirectconfirmation_continues_to_deadend_handler()
        {
            var result = this.handler.Execute(
                new Home.HomeRequestModel()
                {
                    RedirectConfirmation = Home.PostHandler.RedirectConfirm.ToUpper()
                });

            result.AssertWasRedirectedTo<DeadEnd.GetHandler>(x => x.Execute(new DeadEnd.DeadEndViewModel()));
        }

        [Test]
        public void when_calling_excute_with_redirectconfirmation_inmixedcase_continues_to_deadend_handler()
        {
            var result = this.handler.Execute(
                new Home.HomeRequestModel()
                {
                    RedirectConfirmation = Home.PostHandler.RedirectConfirm.ToLower()
                });

            result.AssertWasRedirectedTo<DeadEnd.GetHandler>(x => x.Execute(new DeadEnd.DeadEndViewModel()));
        }

        [Test]
        public void when_calling_execute_with_statuscodeonly_redirects_with_status_code()
        {
            var result = this.handler.Execute(
                new Home.HomeRequestModel()
                {
                    RedirectConfirmation = String.Empty,
                    StatusCode = 500
                });

            result.AssertWasEndedWithStatusCode(System.Net.HttpStatusCode.InternalServerError);
        }

        [Test]
        public void when_calling_execute_with_invalidstatuscodeonly_throws_exception()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var result = this.handler.Execute(
                    new Home.HomeRequestModel()
                    {
                        RedirectConfirmation = String.Empty,
                        StatusCode = 29292
                    });
            });

            Assert.AreEqual("StatusCode not listed", ex.Message);
        }
    }
}
