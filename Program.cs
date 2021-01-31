using System;
using System.IO;
using System.Collections.Generic;

namespace DotNetDb_Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            string choice;
            do {
                Console.WriteLine("1) Read tickets from file.");
                Console.WriteLine("2) Add tickets to file.");
                Console.WriteLine("Enter any other key to exit.");
                choice = Console.ReadLine();
                if (choice == "1") {
                    if (File.Exists(file)) {
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream) {
                            string line = sr.ReadLine();
                            string[] arr = line.Split(',');
                            Console.WriteLine("TicketID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                        }
                        sr.Close();
                    }
                    else {
                        Console.WriteLine("File doesn't exist.");
                    }
                }
                else if (choice == "2") {
                    StreamWriter sw = new StreamWriter(file, append: true);
                    for (int i = 0; i < 200; i++) {
                        Console.WriteLine("Enter a ticket (Y/N)?");
                        string response = Console.ReadLine().ToUpper();
                        if (response != "Y") {break;}
                        Console.WriteLine("Enter TicketID: ");
                        string ticketID = Console.ReadLine();
                        Console.WriteLine("Enter Summary: ");
                        string summary = Console.ReadLine();
                        Console.WriteLine("Enter Status: ");
                        string status = Console.ReadLine();
                        Console.WriteLine("Enter Priority: ");
                        string priority = Console.ReadLine();
                        Console.WriteLine("Enter Submitter: ");
                        string submitter = Console.ReadLine();
                        Console.WriteLine("Enter Assigned: ");
                        string assigned = Console.ReadLine();
                        Console.WriteLine("Enter Watching: ");
                        var watchingList = new List<string>();
                        for (int j = 0; j < 200; j++) {
                            watchingList.Add(Console.ReadLine());
                            Console.WriteLine("Enter another user watching (Y/N)?");
                            string responseWatching = Console.ReadLine().ToUpper();
                            if (responseWatching != "Y") {break;}
                            Console.WriteLine("Enter Watching: ");
                        }
                        string watching = string.Join("|", watchingList);
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ticketID, summary, status, priority, submitter, assigned, watching);
                    }
                    sw.Close();
                }
            }
            while (choice == "1" || choice == "2");
        }
    }
}