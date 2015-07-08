using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhatsNewInCSharp6.Classes;
using WhatsNewInCSharp6.EvilGeniusApp;
using static System.Console;
 
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

        [TestMethod]
        public void Elvis_NullConditionals()
        {
            #region Old Way

            var vender = new Company();
            var location = default(string);

            if (vender != null)
            {
                if (vender.ContactPerson != null)
                {
                    if (vender.ContactPerson.HomeAddress != null)
                    {
                        location = vender.ContactPerson.HomeAddress.LineOne;
                    }
                }
            }

            #endregion Old Way

            #region New Way

            var vender2 = new Company();
            var location2 = vender2?.ContactPerson?.HomeAddress?.LineOne; //You'll get the value or you'll get default value of property

            #endregion New Way
        }

        [TestMethod]
        public void EvilGeniusApplication()
        {
            var evil = new EvilGenius
            {
                Name = "Dr. Evil",
                CatchPhrase = "Sssh",
                Minion = new HenchMen{ Name = "Scott Evil" }
            };

            WriteLine(evil);
        }
    }
}
