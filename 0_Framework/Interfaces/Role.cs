using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Interfaces
{
    public static class Roles
    {
        public const string Doctor = "1";
        public const string Assistant = "2";
        public const string Customer = "3";

        public static string GetRoleBy(string id)
        {
            #region switch
            // switch (id)
            // {
            //     case 1:
            //         return "مدیر سیستم";
            //     case 2:
            //         return "کاربر سیستم";
            //     case 3:
            //         return "محتوا گذار";
            //     case 4:
            //         return "همکار";
            //     default:
            //         return "";
            // }
            #endregion
            return id switch
            {
                Doctor => "دکتر",
                Assistant => "منشی",
                Customer => "مشتری",
                _ => ""
            };
        }
    }
}
