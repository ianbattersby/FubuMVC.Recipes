namespace IAuthorizationPolicyRecipe.Web.Security
{
    using System;
    using System.Collections.Generic;

    public interface IUserData
    {
        IDictionary<string, IEnumerable<string>> AllowedGroups { get; }
    }
}
