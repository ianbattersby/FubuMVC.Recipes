namespace BasicAuthorizationPolicy.Web.Handlers.Account.LogOut
{
    using FubuMVC.Core.Security;
    using Security;

    [AllowRole(RoleReference.Basic)]
    public class LogOutRequestModel
    {
    }
}