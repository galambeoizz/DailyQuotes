using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DailyQuotes
{
    public class Query
    {
        public static int GetMaxQuoteID()
        {
            string sql = "select max(ID) from Quote";
            return (int)SqlHelper.ExecuteScalar(Connection.ConnectionString, System.Data.CommandType.Text, sql);
        }

        public static QuoteModel GetQuote(int id)
        {
            string sql = "select * from Quote where ID=" + id;
            QuoteModel model = new QuoteModel();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(Connection.ConnectionString, System.Data.CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    model.ID = Convert.ToInt32(reader["ID"]);
                    model.Quote = reader["Quote"].ToString();
                    model.Book = reader["Book"].ToString();
                }
            }
            return model;
        }
    }
}
