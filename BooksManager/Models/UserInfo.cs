using System;
using SQLite;

namespace BooksManager.Models
{
    public class UserInfo
    {
        public UserInfo()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string strID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
