﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public class OperationMessages
    {
        //اگر داخل پیامی کلمه های (با موفقیت انجام شد) باشد انرا در کادر سبز نشان می دهد در غیر اینصورت به صورت خطا می باشد
        public const string SuccessKey = "با موفقیت انجام شد";
        public const string RecordNotFound = "مقدار مورد نظر یافت نشد";
        public const string Duplicate = "امکان ثبت رکورد تکراری وجود ندارد";
        public const string DuplicateUser = "کاربری با این شماره موبایل ثبت شده است لطفا شماره موبایل دیگری را امتحان کنید";


        public const string PasswordsNotMatch =
            "پسورد و تکرار آن با هم مطابقت ندارند";

        public const string PasswordOrMobileIsNotOk = "شماره موبایل یا رمز عبور اشتباه است";


        public const string UserNameInValid =
            "کاربری با این مشخصات ثبت نشده است";

        public const string UserNotFound = "کاربری با این مشخصات یافت نشد";
        public const string NotVerifyValid = "کد احراز هویت اشتباه است";
        public const string CantSendCodeWhenTimeIsUp = "امکان ارسال کد تا اتمام زمان کد قبلی وجود ندارد";
    }
}
