using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application.Email
{
    public interface IEmailSender
    {
        OperationResult SendEmail(string email, string code, int timeSendCanBeLong = 20);
    }
}
