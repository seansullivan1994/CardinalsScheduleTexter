using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace CardinalsScheduleTexter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load in the file
            List<string> file = new List<string>(readInFile(@"C:\Users\User\Documents\Cardinals Schedule Full.csv"));
            //Create a list of Schedules
            List<Schedule> cardinalGames = createFullSchedule(file);
            //Compare the dates with today's date
            string todaysDate = DateTime.Now.ToString("MMMM").Substring(0,3) + " " + DateTime.Now.Day;
            //text to string if date matches
            isGameToday(todaysDate, cardinalGames);
        }
        public static bool isGameToday(string todaysDate, List<Schedule> cardGames)
        {
            foreach(Schedule card in cardGames)
            {
                if (card.date == todaysDate)
                {
                    sendTextMessage(card);
                    return true;
                }                  
            }
            Console.WriteLine("No Game today");
            return false;
        }
        public static void sendTextMessage(Schedule cardGame)
        {
           
            using (var client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,

                Credentials = new NetworkCredential("@gmail.com", "password"),
                EnableSsl = true
            })
            {
                client.Send("cardGameEmailer98@gmail.com", "6184475822@vtext.com", "subject", cardGame.ToString());
            }
        }
        public static List<Schedule> createFullSchedule(List<string> file)
        {
            List<Schedule> cardinalGames = new List<Schedule>();
            foreach (string temp in file)
            {
                cardinalGames.Add(createAScheduleItem(temp));
            }
            return cardinalGames;
        }
        public static Schedule createAScheduleItem(string fileLine)
        {
            return new Schedule(fileLine);
        }
        public static string[] readInFile(string filePath)
        {
           return File.ReadAllText(filePath).Split(System.Environment.NewLine);
        }
    }
}
