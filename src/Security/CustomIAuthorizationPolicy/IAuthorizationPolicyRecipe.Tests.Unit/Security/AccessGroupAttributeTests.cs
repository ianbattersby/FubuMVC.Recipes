namespace IAuthorizationPolicyRecipe.Tests.Unit.Security
{
    using System;
    using System.Linq;
    using IAuthorizationPolicyRecipe.Web.Security;
    using NUnit.Framework;

    [TestFixture]
    public class AccessGroupAttributeTests
    {
        [Test]
        public void when_creating_attribute_with_no_groups_has_no_groups()
        {
            var attr = new AccessGroupAttribute();
            Assert.AreEqual(0, attr.Groups.Count());
        }

        [Test]
        public void when_creating_attribute_with_groups_has_all_groups()
        {
            var attr = new AccessGroupAttribute("GroupOne", "GroupTwo", "GroupThree");
            Assert.AreEqual(3, attr.Groups.Count());
        }
    }
}
