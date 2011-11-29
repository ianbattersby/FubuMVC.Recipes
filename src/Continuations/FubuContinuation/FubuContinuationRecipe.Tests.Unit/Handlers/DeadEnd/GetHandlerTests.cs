namespace FubuContinuationRecipe.Tests.Unit.Handlers.DeadEnd
{
    using System;
    using NUnit.Framework;
    using DeadEnd = FubuContinuationRecipe.Web.Handlers.DeadEnd;

    [TestFixture]
    public class GetHandlerTests
    {
        [Test]
        public void when_calling_execute_return_is_not_null()
        {
            var handler = new DeadEnd.GetHandler();
            Assert.IsNotNull(handler.Execute(new DeadEnd.DeadEndViewModel()));
        }
    }
}
