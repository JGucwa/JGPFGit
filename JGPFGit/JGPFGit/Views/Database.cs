using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace JGPFGit.Views
{
    public class Database
    {
        readonly SQLiteAsyncConnection _db;

        public Database(string dbpath)
        {
            _db = new SQLiteAsyncConnection(dbpath);
            _db.CreateTableAsync<Wydatek>().Wait();
        }
        public Task<List<Wydatek>> WszystkieWydatki()
        {
            return _db.Table<Wydatek>().ToListAsync();
        }
        public Task<int> DodajWydatek(Wydatek wydatek)
        {
            return _db.InsertAsync(wydatek);
        }
    }
}
