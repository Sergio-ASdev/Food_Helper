using System;
using System.Collections.Generic;
using System.Text;

namespace Food_helper
{
    public interface IDataBase
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
