namespace WhatsNewInCSharp6.Classes
{
    public class Company
    {
        public Person ContactPerson { get; set; }
    }

    public class Person
    {
        public Address HomeAddress { get; set; }
    }

    public class Address
    {
        public string LineOne { get; set; }
    }
}
