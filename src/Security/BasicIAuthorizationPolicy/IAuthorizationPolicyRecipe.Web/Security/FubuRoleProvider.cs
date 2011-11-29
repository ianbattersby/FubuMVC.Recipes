namespace IAuthorizationPolicyRecipe.Web.Security
{
    using System;
    using System.Linq;
    using System.Web.Security;
    using StructureMap;

    /// <summary>
    /// NOTE! I rolled this in about 2 minutes when I realised ASP.NET didn't provide anything
    /// I could use as an in-memory role provider. DO NOT USE THIS IN PRODUCTION!
    /// </summary>
    public class FubuRoleProvider : RoleProvider
    {
        private readonly IRoleStore roleStore;

        public FubuRoleProvider()
        {
            this.roleStore = ObjectFactory.GetInstance<IRoleStore>();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            foreach (var username in usernames)
            {
                roleStore.AddRole(username, roleNames);
            }
        }

        public override string ApplicationName
        {
            get
            {
                //throw new System.NotImplementedException();
                return "FubuRecipe";
            }
            set
            {
                //throw new System.NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new System.NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            return roleStore.GetUserRoles(username).ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return roleStore.IsUserInRole(username, roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new System.NotImplementedException();
        }
    }
}