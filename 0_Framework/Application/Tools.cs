using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public static class Tools
    {
        private static readonly string[] MonthNames =
            { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

        // public static string[] DayNames = {"شنبه", "یکشنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه"};
        // public static string[] DayNamesG = {"یکشنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه", "شنبه"};
        public static string ToHash(this string usrString)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(usrString);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
            }
        }

        public static string ToPersianDate(this DateTime? date)
        {
            try
            {
                if (date != null) return date.Value.ToPersianDate();
            }
            catch (Exception)
            {
                return "";
            }

            return "";
        }

        public static string ToPersianDate(this DateTime date)
        {
            if (date == new DateTime()) return "";
            var pc = new PersianCalendar();
            return $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
        }

        public static string GetNameOfMonth(this DateTime date)
        {
            try
            {
                if (date == new DateTime()) return "";
                var pc = new PersianCalendar();
                return MonthNames[pc.GetMonth(date) - 1];
            }
            catch
            {
                return "";
            }
        }

        public static string ToFarsiMonthAndDay(this DateTime date)
        {
            if (date == new DateTime()) return "";
            var pc = new PersianCalendar();
            return $"{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
        }

        public static string ToDiscountFormat(this DateTime date)
        {
            return date == new DateTime() ? "" : $"{date.Year}/{date.Month}/{date.Day}";
        }

        public static string GetTime(this DateTime date)
        {
            return $"_{date.Hour:00}_{date.Minute:00}_{date.Second:00}";
        }

        public static string ToFarsiFull(this DateTime date)
        {
            var pc = new PersianCalendar();
            return
                $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00} {date.Hour:00}:{date.Minute:00}:{date.Second:00}";
        }

        private static readonly string[] Pn = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
        private static readonly string[] En = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public static string ToEnglishNumber(this string strNum)
        {
            var cash = strNum;
            for (var i = 0; i < 10; i++)
                cash = cash.Replace(Pn[i], En[i]);
            return cash;
        }

        public static string ToPersianNumber(this int intNum)
        {
            var chash = intNum.ToString();
            for (var i = 0; i < 10; i++)
                chash = chash.Replace(En[i], Pn[i]);
            return chash;
        }

        public static DateTime? FromFarsiDate(this string InDate)
        {
            if (string.IsNullOrEmpty(InDate))
                return null;

            var spited = InDate.Split('/');
            if (spited.Length < 3)
                return null;

            if (!int.TryParse(spited[0].ToEnglishNumber(), out var year))
                return null;

            if (!int.TryParse(spited[1].ToEnglishNumber(), out var month))
                return null;

            if (!int.TryParse(spited[2].ToEnglishNumber(), out var day))
                return null;
            var c = new PersianCalendar();
            return c.ToDateTime(year, month, day, 0, 0, 0, 0);
        }

        public static DateTime GetDateOfLastDayOfMonth(int month)
        {
            if (month is < 1 or > 12) return DateTime.Now;

            var now = DateTime.Now;
            var ps = new PersianCalendar();
            var thisYear = ps.GetYear(now);
            var countOfDaysInThisMonth = ps.GetDaysInMonth(thisYear, month);

            return ps.ToDateTime(thisYear, month, countOfDaysInThisMonth, 23, 59, 59, 999);
        }

        public static DateTime GetDateOfFirstDayOfMonth(int month)
        {
            if (month is < 1 or > 12) return DateTime.Now;

            var now = DateTime.Now;
            var ps = new PersianCalendar();
            var thisYear = ps.GetYear(now);

            return ps.ToDateTime(thisYear, month, 1, 0, 0, 0, 0);
        }

        public static DateTime ToGeorgianDateTime(this string persianDate)
        {
            persianDate = persianDate.ToEnglishNumber();
            var year = Convert.ToInt32(persianDate.Substring(0, 4));
            var month = Convert.ToInt32(persianDate.Substring(5, 2));
            var day = Convert.ToInt32(persianDate.Substring(8, 2));
            return new DateTime(year, month, day, new PersianCalendar());
        }

        public static string ToMoney(this double myMoney)
        {
            return myMoney.ToString("N0", CultureInfo.CreateSpecificCulture("fa-ir"));
        }

        public static string ToFileName(this DateTime date)
        {
            return $"{date.Year:0000}-{date.Month:00}-{date.Day:00}-{date.Hour:00}";
        }
    }
}