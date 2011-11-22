namespace BasicAuthorizationPolicy.Web.Security
{
    using System;
    using System.Collections.Generic;
    using StructureMap.Configuration.DSL;

    public class SecurityRegistry : Registry
    {
        public SecurityRegistry()
        {
            // Believe it or not ASP.NET does not ship with an in-memory role provider, so
            // here's one I rolled earlier.
            For<IRoleStore>()
                .Singleton()
                .Use<RoleStore>();

            // This would most likely be a repository pattern or similar, but hey - hacky hacky!
            For<IUserData>()
                .Use((context) =>
                {
                    return new UserData(
                        new Dictionary<string, IEnumerable<string>>()
                        {
                            {"BasicUser", new string[] { RoleReference.Basic } },
                            {"AdvUser", new string[] { RoleReference.Basic, RoleReference.Advanced } },
                            {"MapsUser", new string[] { RoleReference.Basic, RoleReference.Advanced, RoleReference.Maps } }
                        });
                });
        }
    }
}