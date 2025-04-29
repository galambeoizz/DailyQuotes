using MailKit.Net.Pop3;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyQuotes
{
    internal class Email
    {
        public static void SendEmail(List<QuoteModel> list)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Sender Name", "doducduy92@gmail.com"));
            email.To.Add(new MailboxAddress("Receiver Name", "doducduy92@gmail.com"));

            email.Subject = "1% Better Every Day";
            string text = "";
            foreach (var quote in list)
            {
                text += "<p><b>" + quote.Book + "</b><br>";
                text += quote.Quote + "</p><hr>";
            }

            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = text
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);

                ////Note: only needed if the SMTP server requires authentication
                client.Authenticate("doducduy92@gmail.com", "lcixllazzetdxpyh");

                client.Send(email);
                client.Disconnect(true);
            }
        }
    }
}
