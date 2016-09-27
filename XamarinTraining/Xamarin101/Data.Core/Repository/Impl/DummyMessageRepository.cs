using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Core.Repository.Impl
{
	public class DummyMessageRepository:IMessageRepository
    {
		private IList<string> _messages;

	    public async Task Init(string path)
	    {
			_messages = new List<string> ();
			await Task.FromResult(string.Empty);
	    }

        public async Task WriteMessage(string message)
        {
			_messages.Add(message);
			await Task.FromResult (string.Empty);
        }

	    public async Task<IEnumerable<string>> ReadMessages ()
		{
			
			return await Task.FromResult(_messages);
		}

		public async Task<string> ReadMessage (int id)
		{
			return await Task.FromResult(_messages [id]);
		}

		public async Task DeleteMessages ()
		{
			await Task.FromResult(string.Empty);
			_messages.Clear ();
		}
    }
}