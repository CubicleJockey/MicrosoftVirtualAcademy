using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhatsNewInCSharp6.Classes;
using WhatsNewInCSharp6.EvilGeniusApp;

namespace WhatsNewInCSharp6
{
    [TestClass]
    public class Playground
    {
        [TestMethod]
        public void UsingExpressionBodyMembers()
        {
            var ebmObj = new ExpressionBodyMember
            {
                X = 12,
                Y = 5
            };

            ebmObj.Should().NotBeNull();

            //Distance was created via expression body members.
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

        [TestMethod]
        public void StringFormatting()
        {

            var someObject = new
            {
              Name = "André",
              Minion =  new HenchMen
              {
                  Name = "BeastPet"
              }
            };

            var result = string.Format("{0}, {1}", someObject.Name, someObject.Minion?.Name);

            //New string formatting
            var result2 = $"{someObject.Name}, {someObject.Minion?.Name}";

            result.Should().NotBeNullOrWhiteSpace();
            result2.Should().NotBeNullOrWhiteSpace();

            result.Should().BeEquivalentTo(result2);
        }

        [TestMethod]
        public void NewDictionaryInitialization()
        {
            var webErrors = new Dictionary<int, string>
            {
                [404] = "Page not Found.",
                [302] = "Page moved, but left a forwarding address.",
                [500] = "The web server can't come out to play today."
            };

            webErrors[404].ShouldAllBeEquivalentTo("Page not Found.");
            webErrors[302].ShouldAllBeEquivalentTo("Page moved, but left a forwarding address.");
            webErrors[500].ShouldAllBeEquivalentTo("The web server can't come out to play today.");
        }

        /// <exception cref="IOException">An I/O error occurred. </exception>
        [TestMethod]
        public void Json()
        {
            var drEvil = new EvilGenius2("Dr. Evil");
            Console.WriteLine(EvilGenius2.ToJson(new[] { drEvil }));

            drEvil.ReplaceHenchmen(new HenchMen { Name = "Scott Evil"});
            Console.WriteLine(EvilGenius2.ToJson(new[] { drEvil }));

            drEvil.ReplaceHenchmen(null);
            Console.WriteLine(EvilGenius2.ToJson(new[] { drEvil }));
        }


        [TestMethod]
        public void NameOf()
        {
            //the name of keyword is a way to keep bindings in sync, rather than using a string literal
            //now an object or property rename is changed everywhere

            Console.WriteLine("New Way!");
            Console.WriteLine(nameof(EvilGenius));
            Console.WriteLine(nameof(EvilGenius.Name));

            //Old way
            Console.WriteLine("Old Way");
            Console.WriteLine(typeof(EvilGenius).Name);

            //can't do this one
            //Console.WriteLine(typeof(EvilGenius.Name).Name);


            var drEvil = new EvilGenius2("Dr. Evil");
            drEvil.ReplaceHenchmen(new HenchMen { Name = "Scott Evil"});

            Console.WriteLine(drEvil);
        }
    }
}
