using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.Core.Models;

namespace WebService.Core.Services.People
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetPeople();
        Task StorePerson(Person person);
    }


    public class Rootobject
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string[] Genres { get; set; }
    }

}