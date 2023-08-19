using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application.Email
{
    public class EmailSender : IEmailSender
    {
        public OperationResult SendEmail(string email, string code, int timeSendCanBeLong = 20)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < timeSendCanBeLong)
            {
                // send email
            }
            timer.Stop();
            return new OperationResult().Succdded();
        }
    }
}
