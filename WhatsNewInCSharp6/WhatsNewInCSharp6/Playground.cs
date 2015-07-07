using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhatsNewInCSharp6.Classes;

namespace WhatsNewInCSharp6
{
    [TestClass]
    public class Playground
    {
        [TestMethod]
        public void ExpressionBodyMember()
        {
            var ebm = new ExpressionBodyMember
            {
                X = 3,
                Y = 4
            };

            ebm.Should().NotBeNull();

            ebm.Distance.ShouldBeEquivalentTo(5);
        }
    }
}
