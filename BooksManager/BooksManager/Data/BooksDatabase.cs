using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using BooksManager.Models;

namespace BooksManager.Data
{
    public class BooksDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public string dbPath;

        public BooksDatabase(string _dbPath)
        {
            dbPath = _dbPath;
            _database = new SQLiteAsyncConnection(_dbPath);
            _database.CreateTableAsync<BookInfo>().Wait();
            _database.CreateTableAsync<UserInfo>().Wait();
            _database.CreateTableAsync<RecordInfo>().Wait();
        }

        public Task<List<BookInfo>> GetBooksInfoAsync()
        {
            return _database.Table<BookInfo>().ToListAsync();
        }

        public Task<BookInfo> GetBookInfoAsync(int id)
        {
            return _database.Table<BookInfo>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> AddBookInfoAsync(BookInfo book)
        {
            book.strLent = book.Lent ? "借出" : "在馆";
            return _database.InsertAsync(book);
        }

        public Task<int> SaveBookInfoAsync(BookInfo book)
        {
            book.strLent = book.Lent ? "借出" : "在馆";
            return _database.UpdateAsync(book);
        }

        public Task<int> DeleteBookInfoAsync(BookInfo book)
        {
            return _database.DeleteAsync(book);
        }

        public Task<int> BorrowBookAsync(BookInfo book)
        {
            book.Lent = true;
            var record = new RecordInfo();
            record.BookID = book.ID;
            record.UserID = App.CurrentUser.ID;
            record.Returned = false;
            record.strReturned = "未还";
            record.BookName = book.Name;
            record.Date = DateTime.UtcNow;
            _database.InsertAsync(record);
            return SaveBookInfoAsync(book);
        }

        async public Task<int> ReturnBookAsync(RecordInfo record)
        {
            record.Returned = true;
            record.strReturned = "已还";
            var book = await GetBookInfoAsync(record.BookID);
            await _database.UpdateAsync(record);

            book.Lent = false;
            return await SaveBookInfoAsync(book);
        }

        async public Task<int> GetMaxBookID()
        {
            return await _database.ExecuteScalarAsync<int>("SELECT max(ID) from BookInfo");
        }

        async public Task<List<BookInfo> > SearchBookInfoAsync(string keyword)
        {
            string query = "SELECT * from BookInfo where Name LIKE '%" + keyword + "%' OR Author LIKE '%" + keyword + "%' --case-insensitive";
            return await _database.QueryAsync<BookInfo>(query);
        }

        public Task<int> CreateNewUser(UserInfo NewUser)
        {
            return _database.InsertAsync(NewUser);
        }

        public Task<UserInfo> GetUserInfoAsync(int id)
        {
            return _database.Table<UserInfo>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> GetMaxUserID()
        {
            return await _database.ExecuteScalarAsync<int>("SELECT count(*) from UserInfo");
        }

        public Task<List<RecordInfo>> GetRecordsInfoAsync(int UserID, bool Only)
        {
            return _database.Table<RecordInfo>()
                            .Where(i => i.UserID == UserID && (Only == false || i.Returned == false))
                            .ToListAsync();
        }

        public bool TryLogin(int id, string pw)
        {
            var result = _database.Table<UserInfo>()
                                  .Where(i => i.ID == id)
                                  .FirstOrDefaultAsync()
                                  .Result;
            if (result == null) return false;
            return result.Password == pw;
        }
    }
}
