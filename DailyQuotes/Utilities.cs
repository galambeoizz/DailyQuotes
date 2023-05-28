using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyQuotes
{
    public class Utilities
    {
        public static string ReadDate() 
        {
            string textFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\date.txt";
            string text = File.ReadAllText(textFile);
            return text;
        }

        public static void WriteDate() 
        {
            string textFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\date.txt";
            string text = DateTime.Today.AddDays(1).ToString("yyyyMMdd");
            File.WriteAllText(textFile, text);
        }

        public static void CompareDate()
        {
            string text = ReadDate();
            string today = DateTime.Today.ToString("yyyyMMdd");
            if (Convert.ToInt32(text) <= Convert.ToInt32(today))
            {
                var list = GetQuoteList();

                //test
                //string textFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\log.txt";
                //string log = "";
                //foreach ( var item in list ) 
                //{
                //    log += item.ID + ", ";
                //}
                //File.WriteAllText(textFile, log);

                Email.SendEmail(list);
                WriteDate();
            }
        }

        public static List<QuoteModel> GetQuoteList()
        {
            var list = new List<QuoteModel>();
            int NoQuotes = 3;
            Random r = new Random();
            int maxQuoteID = Query.GetMaxQuoteID();
            for (int i = 0; i < NoQuotes; i++)
            {
                
                int rInt = r.Next(1, maxQuoteID);
                var quote = Query.GetQuote(rInt);
                list.Add(quote);
            }
            return list;
        }
    }
}
