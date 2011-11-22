namespace BasicAuthorizationPolicy.Web.Security
{
    public static class RoleReference
    {
        /// <summary> Access to the basic site (e.g. Home page). </summary>
        public const string Basic = "BASIC_ACCESS";

        /// <summary> Access to areas of the site classed as advanced. </summary>
        public const string Advanced = "ADVANCED_ACCESS";

        /// <summary> Access to the dummy 'maps' section. </summary>
        public const string Maps = "MAPS_ACCESS";
    }
}