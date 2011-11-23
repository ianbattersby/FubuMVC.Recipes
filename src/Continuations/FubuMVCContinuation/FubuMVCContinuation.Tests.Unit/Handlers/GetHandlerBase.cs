namespace FubuMVCContinuation.Tests.Unit.Handlers
{
    using System;
    using NUnit.Framework;

    public class GetHandlerBase<TGetHandler> where TGetHandler : class, new()
    {
        [Test]
        public void when_calling_execute_return_is_not_null()
        {
            var result = new TGetHandler();
            Assert.IsNotNull(result);
        }
    }
}
