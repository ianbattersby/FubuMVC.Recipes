namespace CustomAuthorizationPolicy.Web.Security
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Custom attribute to attach to our FubuMVC handles
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AccessGroupAttribute : Attribute
    {
        private string[] accessGroups;

        public AccessGroupAttribute()
        {
            this.accessGroups = new string[0];
        }

        public AccessGroupAttribute(params string[] groups)
        {
            this.accessGroups = groups;
        }

        public IEnumerable<string> Groups
        {
            get
            {
                return this.accessGroups;
            }
        }
    }
}