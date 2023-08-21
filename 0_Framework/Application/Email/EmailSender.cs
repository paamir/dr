using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application.Email
{
    public class EmailSender : IEmailSender
    {
        public OperationResult SendEmail(string email, string code, int timeSendCanBeLong = 3)
        {
            var result = new OperationResult();
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("drReserverSdata@outlook.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = "کد یک بار مصرف فراموشی رمز عبور";
            mailMessage.Body = $"لطفا این کد را در اختیار هیچکس قرار ندهید کد شما : {code}";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp-mail.outlook.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential("drReserverSdata@outlook.com", "Asd/8520");
            smtpClient.EnableSsl = true;

           

            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < timeSendCanBeLong)
            {
                try
                {
                    smtpClient.Send(mailMessage);
                    Console.WriteLine("Email Sent Successfully.");
                    return result.Succdded();

                }
                catch (Exception e)
                {
                    // ignored
                }
            }

            timer.Stop();
            return result.Failed(OperationMessages.CantSendEmailTryAgain);
        }
    }
}