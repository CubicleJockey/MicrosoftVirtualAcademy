using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhatsNewInCSharp6.Classes;

namespace WhatsNewInCSharp6
{
    [TestClass]
    public class Playground
    {
        [TestMethod]
        public void UsingExpressionBodyMemebers()
        {
            var ebmObj = new ExpressionBodyMember
            {
                X = 12,
                Y = 5
            };

            ebmObj.Should().NotBeNull();

            //Distance was created via expression body memebers.
            ebmObj.Distance.ShouldBeEquivalentTo(13);
        }

        [TestMethod]
        public void ElvisOperator()
        {
            var company = new Company
            {
                ContactPerson = new Person
                {
                    HomeAddress = new Address
                    {
                        LineOne = "1234 Batcave"
                    }
                }
            };

            company.Should().NotBeNull();

            //using new null check operators
            var lineOne = company.ContactPerson?.HomeAddress?.LineOne;
            lineOne.Should().NotBeNullOrWhiteSpace();
            lineOne.Should().BeEquivalentTo("1234 Batcave");


            var company2 = new Company
            {
                ContactPerson = new Person
                {
                    HomeAddress = null
                }
            };

            var lineOne2 = company2.ContactPerson?.HomeAddress?.LineOne;
            lineOne2.Should().BeNull();
        }
    }
}
