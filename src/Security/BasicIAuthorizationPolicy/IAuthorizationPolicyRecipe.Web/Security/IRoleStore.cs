namespace IAuthorizationPolicyRecipe.Web.Security
{
    using System;
    using System.Collections.Generic;

    public interface IRoleStore
    {
        void AddRole(string username, params string[] roles);
        void ClearRoles(string username);
        void DeleteRole(string username, params string[] roles);
        bool IsUserInRole(string username, string role);
        IEnumerable<string> GetUserRoles(string username);
    }
}
