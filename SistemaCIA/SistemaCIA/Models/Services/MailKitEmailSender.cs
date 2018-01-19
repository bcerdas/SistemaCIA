using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp; // or POP3


//https://code.msdn.microsoft.com/Send-Email-Using-ASPNET-1c62bdfd/sourcecode?fileId=171277&pathId=1948400523   mailkit tutorial

namespace SistemaCIA.Models.Services
{
    public class MailKitEmailSender : IEmailSender
    {
        public string SendEmail(string email, string subject, string message)
        {
            string result = "fail";//resultado del envio
            string FromAddress = "userssignin@gmail.com";
            string FromAddressName = "Atlex Users";
            string password = "atlex1234";
            string SmtpServer = "smtp.gmail.com";
            int SmtpPort = 465;
            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(FromAddressName, FromAddress));
            mimeMessage.To.Add(new MailboxAddress(email));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart("html")
            {
                Text = message
            };
            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect(SmtpServer, SmtpPort, true); // Note: only needed if the SMTP server requires authentication 
                    //Error 5.5.1 Authentication
                    client.Authenticate(FromAddress, password);
                    client.Send(mimeMessage);
                    result = "exito";

                }
            }
            catch (Exception)
            {
                result = "fail";
            }


            return result;
        }
    }
}



