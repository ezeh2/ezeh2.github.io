using System.Linq;
using System.Threading.Tasks;
using SQLite;
using System.Collections.Generic;
using Data.Core.Repository.Model;
using System;

namespace Data.Core.Repository.Impl
{
    public class MessageRepository:IMessageRepository
    {
        private string _databasePath;

        public async Task Init(string subdirectory)
        {
			_databasePath = System.IO.Path.Combine(subdirectory, "Messages.db");
            var connection = new SQLiteAsyncConnection(_databasePath);
			await connection.CreateTableAsync<Message> ();
        }

		public async Task<IEnumerable<string>> ReadMessages()
		{
			var connection = new SQLiteAsyncConnection (_databasePath);
			var messages = await connection.Table<Message> ().ToListAsync ();
			return messages.Select (m => m.MessageString);
		}

		public async Task<string> ReadMessage(int id)
        {
            var connection = new SQLiteAsyncConnection(_databasePath);
			var message = await connection.Table<Message> ().Where(m => m.Id == id).FirstOrDefaultAsync ();

            return  message?.MessageString ?? "No message stored";
        }

        public async Task WriteMessage(string messageString)
        {
            var message = new Message {MessageString = messageString};

            var connection = new SQLiteAsyncConnection(_databasePath);

            await connection.InsertAsync(message);
        }

		public async Task DeleteMessages()
		{
			var connection = new SQLiteAsyncConnection(_databasePath);
			await connection.DropTableAsync<Message> ();
			await connection.CreateTableAsync<Message> ();
		}
    }

}
