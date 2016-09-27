using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.Core.Handlers.Http;
using WebService.Core.Models;

namespace WebService.Core.Services.People.Impl
{
    public class PersonService:IPersonService
    {
        private readonly IHttpHandler _httpHandler;

        public PersonService(IHttpHandler httpHandler)
        {
            if (httpHandler == null) throw new ArgumentNullException(nameof(httpHandler));
            _httpHandler = httpHandler;
        }

        public Task<IEnumerable<Person>> GetPeople()
        {
            var people = _httpHandler.GetPeople();

            // Implement caching here

            return people;
        }

        public Task StorePerson(Person person)
        {
            return _httpHandler.PostPerson(person);
        }
    }
}
