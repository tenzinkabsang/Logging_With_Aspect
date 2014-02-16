using System.Collections.Generic;
using System.Linq;

namespace Logging
{
    public interface IService
    {
        void Save(Person person, IEnumerable<Address> addresses);

        Person GetByAddresses(int id, Address address);
    }

    public class Service : IService
    {
        private static readonly IList<Person> _people = new List<Person>();

        public void Save(Person person, IEnumerable<Address> addresses)
        {
            person.Addresses = new List<Address>(addresses);  
            _people.Add(person);
        }

        public Person GetByAddresses(int id, Address address)
        {
            Person person = _people.First(p => p.Id == id);

            return person;
        }
    }
}