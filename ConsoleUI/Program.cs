﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            DemonstrateTextFileStorage();

            Console.WriteLine();
            Console.Write("Press enter to shut down...");
            Console.ReadLine();
        }

        private static void DemonstrateTextFileStorage()
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();
            string peopleFile = @"C:\Temp\people.csv";
            string logFile = @"C:\Temp\logs.csv";

            PopulateLists(people, logs);

            GenericTextFileProcessor.SaveToTextFile<Person>(people, peopleFile);
            GenericTextFileProcessor.SaveToTextFile<LogEntry>(logs, logFile);

            var newPeople = GenericTextFileProcessor.LoadFromTextFile<Person>(peopleFile);

            foreach (var p in newPeople)
            {
                Console.WriteLine($"{ p.FirstName } { p.LastName } (IsAlive = { p.IsAlive })");
            }

            Console.WriteLine();

            var newLogs = GenericTextFileProcessor.LoadFromTextFile<LogEntry>(logFile);

            foreach (var l in newLogs)
            {
                Console.WriteLine($"{ l. ErrorCode} { l.Message } at { l.TimeOfEvent.ToShortTimeString() })");
            }

            /* Old way*/
            //OriginalTextFileProcessor.SavePeople(people, peopleFile);

            //var newPeople = OriginalTextFileProcessor.LoadPeople(peopleFile);

            //foreach (var p in newPeople)
            //{
            //    Console.WriteLine($"{ p.FirstName } { p.LastName } (IsAlive = { p.IsAlive })");
            //}
        }

        private static void PopulateLists(List<Person> people, List<LogEntry> logs)
        {
            people.Add(new Person { FirstName = "Tim", LastName = "Corey" });
            people.Add(new Person { FirstName = "Sue", LastName = "Storm", IsAlive = false });
            people.Add(new Person { FirstName = "Greg", LastName = "Olsen" });

            logs.Add(new LogEntry { Message = "I blew up", ErrorCode = 9999 });
            logs.Add(new LogEntry { Message = "I'm too awesome", ErrorCode = 1337 });
            logs.Add(new LogEntry { Message = "I was tired", ErrorCode = 2222 });
        }
    }
}
