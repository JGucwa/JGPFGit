using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace JGPFGit.Views
{
    public class Wydatek
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Nazwa { get; set; }
        public decimal Kwota { get; set; }
    }
}
