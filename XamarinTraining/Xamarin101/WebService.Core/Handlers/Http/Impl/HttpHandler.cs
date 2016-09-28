using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebService.Core.Models;

namespace WebService.Core.Handlers.Http.Impl
{
    public class HttpHandler:IHttpHandler
    {
        private HttpClient _httpClient;
        private const string BaseUrl = "https://xamarinwebservice.azurewebsites.net/api/";

        public HttpHandler()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            var uri = $"{BaseUrl}person/";

            var result = await _httpClient.GetAsync(uri);

            var peopleJsonString = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<Person>>(peopleJsonString);
        }

        public async Task PostPerson(Person person)
        {
            var uri = $"{BaseUrl}person/";

            var personJson = JsonConvert.SerializeObject(person);
            var content = new StringContent(personJson, Encoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync(uri, content);
            var gna = result.IsSuccessStatusCode;
        }

    }
}