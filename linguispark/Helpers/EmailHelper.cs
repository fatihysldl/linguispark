using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
namespace linguispark.Helpers
{
    public static class EmailHelper
    {
        public static void SendEmail(string toAddress, string subject, string body)
        {
            var fromAddress = new MailboxAddress("LINGUISPARK", "linguispark@gmail.com"); // Gönderici adı ve e-posta adresi
            var password = "declxrdmzzpqmfgh"; // Gönderici e-posta hesabının şifresi

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(fromAddress.Name, fromAddress.Address));
            message.To.Add(new MailboxAddress("", toAddress));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = body;
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate(fromAddress.Address, password);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}