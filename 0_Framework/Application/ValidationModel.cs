using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public static class ValidationModel
    {
        public const string IsRequired = "این فیلد نمی تواند خالی باشد";
        public const string MaxFileSize = "حجم فایل بیشتر از حجم مجاز می باشد";
        public const string FileExtension = "فرمت فایل وارد شده صحیح نمی باشد";
        public const string OutOfRange = "مقدار وارد شده خارج از محدوده قابل دسترس است";
        public const string PasswordCompare = "رمز عبور و تکرا رمز عبور با هم تطابق ندارند";
        public const string MobileNotValid = "شماره موبایل معتبر نیست";
        public const string IsNotEmail = "لطفا مقدار ایمیل را به درستی وارد نمایید";
    }
}
