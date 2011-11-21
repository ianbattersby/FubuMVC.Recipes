namespace CustomAuthorizationPolicy.Web.Security
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using FubuMVC.Core.Runtime;
    using FubuMVC.Core.Security;

    public class AccessGroupAuthorizationPolicy<THandler> : IAuthorizationPolicy
    {
        private readonly ISecurityContext securityContext;
        private readonly IUserData userData;

        /// <summary>
        /// Important to note that IoC configuration for ISecurityContext is out-of-the-box.
        /// </summary>
        public AccessGroupAuthorizationPolicy(
            ISecurityContext securityContext,
            IUserData userData)
        {
            this.securityContext = securityContext;
            this.userData = userData;
        }

        public AuthorizationRight RightsFor(IFubuRequest request)
        {
            Type endpointType = typeof(THandler);
            MemberInfo memberInfo = endpointType;

            AccessGroupAttribute[] requiredAttrs = memberInfo
                .GetCustomAttributes(false)
                .Where(x => typeof(AccessGroupAttribute).IsAssignableFrom(x.GetType()))
                .Cast<AccessGroupAttribute>()
                .ToArray();

            if (requiredAttrs.Length == 0)
            {
                return AuthorizationRight.Deny;
            }

            if (requiredAttrs.Length == 1 && requiredAttrs.ElementAt(0).Groups.Count() == 0)
            {
                return AuthorizationRight.Allow;
            }

            if (securityContext == null || securityContext.CurrentUser == null || securityContext.CurrentUser.Identity == null)
            {
                return AuthorizationRight.Deny;
            }

            if (!securityContext.CurrentUser.Identity.IsAuthenticated)
            {
                return AuthorizationRight.Deny;
            }

            var requiredGroups = requiredAttrs.ElementAt(0).Groups.ToArray();

            if (this.userData.AllowedGroups.ContainsKey(securityContext.CurrentUser.Identity.Name) && requiredGroups.Count(x => this.userData.AllowedGroups[securityContext.CurrentUser.Identity.Name].Count(y => y.Equals(x, StringComparison.CurrentCultureIgnoreCase)) > 0) == requiredGroups.Length)
            {
                return AuthorizationRight.Allow;
            }

            return AuthorizationRight.Deny;
        }
    }
}