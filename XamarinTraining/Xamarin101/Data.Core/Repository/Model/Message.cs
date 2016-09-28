using System.Linq;
using System.Threading.Tasks;
using SQLite;
using System.Collections.Generic;

namespace Data.Core.Repository.Model
{

    public class Message
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string MessageString { get; set; }
    }
}
