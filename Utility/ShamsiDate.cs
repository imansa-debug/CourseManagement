using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Utility
{
    public static class ShamsiDate
    {
        
        public static string DateDiffrence(DateTime nowDate,DateTime lastDate) {
            PersianCalendar pc = new PersianCalendar();

            int YearDiff =pc.GetYear(nowDate) - pc.GetYear(lastDate);
            int MonthDiff = pc.GetMonth(nowDate) - pc.GetMonth(lastDate);
            int DayDiff = pc.GetDayOfMonth(nowDate) - pc.GetDayOfMonth(lastDate);
            int HourDiff = nowDate.Hour - lastDate.Hour;
            int MinuteDiff = nowDate.Minute - lastDate.Minute;
            int SecondDiff = nowDate.Second - lastDate.Second;
            if (YearDiff > 0)
                return YearDiff.ToString() + "سال پیش";
            else if (MonthDiff > 0)
                return MonthDiff.ToString() + "ماه پیش";
            else if (DayDiff > 0)
                return DayDiff.ToString() + "روز پیش";
            else if (HourDiff > 0)
                return HourDiff.ToString() + "ساعت پیش";
            else if (MinuteDiff > 0)
                return MinuteDiff.ToString() + "دقیقه پیش";
            else
            {
                return SecondDiff.ToString() + "ثانیه پیش";
            }



        }

        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" + pc.GetDayOfMonth(value).ToString("00");

        }

        public static string ShamsiDayOfWeek(this DateTime value)
        {
            string dayOfWeek = value.DayOfWeek.ToString();
            switch (dayOfWeek)
            {
                case "Sunday":
                    return "یکشنبه";
                case "Monday":
                    return "دوشنبه";
                case "Tuesday":
                    return "سه شنبه";
                case "Wednsday":
                    return "چهارشنبه";
                case "Thursday":
                    return "پنجشنبه";
                case "Friday":
                    return "جمعه";
                default:
                    return "شنبه";
                    
            }

        }


    }
}
