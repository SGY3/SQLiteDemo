using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.MVVM.Utility
{
    public static class DbConnection
    {
        private const string DbFileName = "Maui.db";
        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite |
                                             SQLiteOpenFlags.Create |
                                             SQLiteOpenFlags.SharedCache;
        public static string DbPath
        {
            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, DbFileName);
            }
        }

    }
}
