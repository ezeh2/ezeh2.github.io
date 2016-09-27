using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Core.Repository
{
    public interface IMessageRepository
    {
        Task Init(string path);
		Task<IEnumerable<string>> ReadMessages ();
		Task<string> ReadMessage(int id);
        Task WriteMessage(string message);
		Task DeleteMessages();
    }
}