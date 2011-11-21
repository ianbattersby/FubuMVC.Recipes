namespace CustomAuthorizationPolicy.Web.Handlers.Account.LogOn
{
    using System;
    using Security;

    [AccessGroup()]
    public class GetHandler
    {
        public LogOnViewModel Execute()
        {
            return new LogOnViewModel();
        }
    }
}