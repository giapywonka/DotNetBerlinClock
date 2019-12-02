using System;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {

        private const string OFF = "O";
        private const string RED = "R";
        private const string YELLOW = "Y";

        private string ConvertSeconds(int seconds)
        {
            return seconds % 2 == 0 ? YELLOW : OFF;
        }

        private string ConvertMinutes(int minutes)
        {
            string result = "";
            for (int i=5; i<=55; i+=5)
            {
                if (i % 15 == 0)
                    result += i <= minutes ? RED : OFF;
                else
                    result += i <= minutes ? YELLOW : OFF;
            }
            result +=  Environment.NewLine;
            int rest = minutes % 5;
            for (int i=1; i<=4; i++)
            {
                result += i <= rest ? YELLOW : OFF;
            }
            return result;
        }

        private string ConvertHours(int hours)
        {
            string result = "";
            for (int i = 5; i <= 20; i += 5)
            {
                result += i <= hours ? RED : OFF;
            }
            result += Environment.NewLine;
            int rest = hours % 5;
            for (int i = 1; i <= 4; i++)
            {
                result += i <= rest ? RED : OFF;
            }
            return result;
        }


        public string convertTime(string aTime)
        {
            string error = "INVALID TIME";
            if (aTime == null)
            {
                return error;
            }

            string[] values = aTime.Split(':');
            if (values.Length != 3)
            {
                return error;
            }

            int hours;
            int minutes;
            int seconds;
            if (!Int32.TryParse(values[0], out hours) ||
                !Int32.TryParse(values[1], out minutes) ||
                !Int32.TryParse(values[2], out seconds))
            {
                return error;
            }

            if (hours < 0 || hours > 24
                || minutes < 0 || minutes > 59
                || seconds < 0 || seconds > 59)
            {
                return error;
            }
            
            return ConvertSeconds(seconds) + Environment.NewLine 
                + ConvertHours(hours) + Environment.NewLine 
                + ConvertMinutes(minutes);
        }
    }
}
