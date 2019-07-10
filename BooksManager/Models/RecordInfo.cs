using System;
using SQLite;

namespace BooksManager.Models
{
    public class RecordInfo
    {
        public RecordInfo()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }
        public bool Returned { get; set; }
        public string strReturned { get; set; }
        public string BookName { get; set; }
        public DateTime Date { get; set; }
    }
}
