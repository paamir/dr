using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public class OperationResult
    {
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }

        public OperationResult()
        {
            IsSuccedded = false;
        }
        //اگر داخل پیامی کلمه های (با موفقیت انجام شد) باشد انرا در کادر سبز نشان می دهد در غیر اینصورت به صورت خطا می باشد
        public OperationResult Succdded(string message = "عملیات با موفقیت انجام شد")
        {
            Message = message;
            IsSuccedded = true;
            return this;
        }
        public OperationResult Failed(string message)
        {
            Message = message;
            IsSuccedded = false;
            return this;
        }
    }
}
