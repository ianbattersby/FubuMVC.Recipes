namespace IAuthorizationPolicyRecipe.Web.Security
{
    using System;
    using System.Collections.Generic;

    public class UserData : IUserData
    {
        public UserData(IDictionary<string, IEnumerable<string>> allowedGroups)
        {
            this.AllowedGroups = allowedGroups;
        }

        public IDictionary<string, IEnumerable<string>> AllowedGroups { get; private set; }
    }
}