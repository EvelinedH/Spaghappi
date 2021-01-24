using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Spaghappi.Services
{
    public interface ISQLiteDatabase
    {
        SQLiteAsyncConnection SQLiteDatabase { get; set; }
    }
}
