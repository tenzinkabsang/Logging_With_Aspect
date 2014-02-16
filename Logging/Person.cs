using System.Collections.Generic;

namespace Logging
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Xml { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }
}