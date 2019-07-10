using System;
using SQLite;

namespace BooksManager.Models
{
    public class BookInfo
    {
        public BookInfo()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public bool Lent { get; set; }
        public string strLent { get; set; }
    }
}
