using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWindowsApp
{
    public static class sqlConnectionStrings
    {
        public static string FDbString(string dbAsk)
        {
            if (dbAsk == "data")
                return "Data Source=SOLSTICE\\SQLEXPRESS;Initial Catalog=FormDb;Integrated Security=True;";
            else
                return "Data Source=SOLSTICE\\SQLEXPRESS;Initial Catalog=UserDb;Integrated Security=True;";
        }
    }
}
