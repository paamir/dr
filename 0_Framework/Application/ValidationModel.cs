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
        public const string PasswordNotValid = "پسورد حتما باید 6 حرف یا بیشتر باشد و حداقل از یک حرف انگلیسی و یک عدد استفاده بشود";
        public const string TokenNotExpire = "کد فراموشی رمز عبور برای شما ارسال شده است لطفا تا پایان زمان کد قبلی صبر نمایید و دوباره تلاش نمایید با تشکمر";
        public const string TokenIsWrong = "کد اشتباه است پس از برسسی مجدد دوباره تلاش کنید";
        public const string TokenExpired = "زمان شما برای انجام عملیات به اتمام رسیده است";
    }
}
