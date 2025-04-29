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

                Email.SendEmail(list);
                WriteDate();
            }
        }

        public static List<QuoteModel> GetQuoteList()
        {
            var list = new List<QuoteModel>();
            int maxQuoteID = Query.GetMaxQuoteID();

            int batch1 = (int)Math.Floor((decimal)maxQuoteID / 3);
            int batch2 = batch1 * 2;

            Sleep();
            list.Add(GetQuote(1, batch1));
            Sleep();
            list.Add(GetQuote(batch1, batch2));
            Sleep();
            list.Add(GetQuote(batch2, maxQuoteID));
            return list;
        }

        static void Sleep()
        {
            Random r = new Random();
            var rInt = r.Next(2, 8);
            System.Threading.Thread.Sleep(rInt * 1234);
        }

        static QuoteModel GetQuote(int min, int max)
        {
            Random r = new Random();
            var rInt = r.Next(min, max + 1);
            return Query.GetQuote(rInt);
        }
    }
}
