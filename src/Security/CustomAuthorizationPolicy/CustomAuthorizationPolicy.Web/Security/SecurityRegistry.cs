namespace CustomAuthorizationPolicy.Web.Security
{
    using System;
    using StructureMap.Configuration.DSL;
using System.Collections.Generic;

    public class SecurityRegistry : Registry
    {
        public SecurityRegistry()
        {
            For<IFormsAuthenticationWrapper>()
                .Use<FormsAuthenticationWrapper>();

            // Normally you might fetch user data from a repository or similar, for the
            // purposes of this recipe we're just injecting test data.

            For<IUserData>()
                .Use((context) =>
                {
                    return new UserData(
                        new Dictionary<string, IEnumerable<string>>()
                        {
                            {"BasicUser", new string[] { AccessGroupReference.Basic } },
                            {"AdvUser", new string[] { AccessGroupReference.Basic, AccessGroupReference.Advanced } },
                            {"MapsUser", new string[] { AccessGroupReference.Basic, AccessGroupReference.Advanced, AccessGroupReference.Maps } }
                        });
                });
        }
    }
}