using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.Core.Models;

namespace WebService.Core.Handlers.Http
{
    public interface IHttpHandler
    {
        Task<IEnumerable<Person>> GetPeople();
        Task PostPerson(Person person);
    }
}