using System;
using System.Collections.Generic;
using System.Text;

namespace CardinalsScheduleTexter
{
    public class Schedule
    {
        private string Date { get; set; }
        public string date
        {
            get { return this.Date; }

            set { this.Date = value; }

        }
        private string Time { get; set; }
        public string time
        {
            get { return this.Time; }

            set { this.Time = value; }

        }
        private string Opponent { get; set; }
        public string opponent
        {
            get { return this.Opponent; }

            set { this.Opponent = value; }

        }

        public Schedule(string csvString)
        {
            List<string> values = new List<string>(csvString.Split(","));
            date = values[0];
            time = values[2];
            opponent = values[1];
        }

        public override string ToString()
        {
            return "The game is today @ " + time + ", against " + opponent+".";
        }
    }
}
