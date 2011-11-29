namespace IAuthorizationPolicyRecipe.Web.Security
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// NOTE! I rolled this in about 2 minutes when I realised ASP.NET didn't provide anything
    /// I could use as an in-memory role provider. DO NOT USE THIS IN PRODUCTION!
    /// </summary>
    public class RoleStore : IRoleStore
    {
        private readonly IDictionary<string, IList<string>> roles;
        private readonly object _lock = new object();

        public RoleStore()
        {
            this.roles = new Dictionary<string, IList<string>>();
        }

        public void AddRole(string username, params string[] roles)
        {
            lock (this._lock)
            {
                if (!this.roles.ContainsKey(username))
                {
                    this.roles.Add(username, new List<string>());
                }

                roles.Each(x =>
                {
                    if (this.roles[username].Count(r => x.Equals(r, StringComparison.CurrentCultureIgnoreCase)) == 0)
                    {
                        this.roles[username].Add(x);
                    }
                });
            }
        }

        public void ClearRoles(string username)
        {
            lock (this._lock)
            {
                if (this.roles.ContainsKey(username))
                {
                    this.roles[username].Clear();
                }
            }
        }

        public void DeleteRole(string username, params string[] roles)
        {
            lock (this._lock)
            {
                if (this.roles.ContainsKey(username))
                {
                    roles.Each((x) =>
                    {
                        this.roles[username].Remove(x);
                    });
                }
            }
        }

        public bool IsUserInRole(string username, string role)
        {
            if (this.roles.ContainsKey(username))
            {
                return false;
            }

            return this.roles[username].Count(x => x.Equals(role, StringComparison.CurrentCultureIgnoreCase)) > 0;
        }

        public IEnumerable<string> GetUserRoles(string username)
        {
            if (this.roles.ContainsKey(username))
            {
                return this.roles[username];
            }

            return new string[0];
        }
    }
}