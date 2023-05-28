using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyQuotes
{
    public class Connection
    {
        static string Server = "SGLT22042";
        static string Username = "sa";
        static string Password = "P@$$w0rd";
        static string Database = "DailyQuotes";
        public static string ConnectionString = "Server=" + Server +
                                                    ";Database=" + Database +
                                                    ";User Id=" + Username +
                                                    ";Password=" + Password + ";";
    }
}
