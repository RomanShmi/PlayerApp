using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using System.Globalization;  //csv librararies
using CsvHelper;               //csv librararies
using CsvHelper.Configuration;   //csv librararies
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp4
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
          
          


            List < BaseUnit > players= new List<BaseUnit>();


            /// <summary>
            /// Read players from csv file
            /// </summary>
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false,
                Comment = '#',
                AllowComments = true,
                Delimiter = "; ",
            };

            using var streamReader = File.OpenText("../../../data.csv");
            using var csvReader = new CsvReader(streamReader, csvConfig);

            while (csvReader.Read())
            {
                var firstName = csvReader.GetField(0);
                var email = csvReader.GetField(1);

                Player pf = new();
                pf.Name = firstName;
                pf.Email = email;
                Console.WriteLine(pf.Id + "  " + pf.Name + " " + pf.Email);
                players.Add(pf);


            }

           



            bool addPlayer = false;

            
            while (!addPlayer)
            {
                Console.WriteLine("if you wont to add PLAYER to list click y");
                if (Console.ReadLine().ToLower() == "y")
                {
                    Player p = new();
                    Console.WriteLine("   enter name");
                    p.Name = Console.ReadLine();
                    Console.WriteLine("   enter email");
                    p.Email = Console.ReadLine();
                    p.PrintInfo();
                    
                    players.Add(p);


                }
                else { addPlayer = true; 
                Console.WriteLine("no more players to add \n \n");
                
                }

            }            
            
            
            
            foreach (Player p in players)
            {
                p.PrintInfo();
                p.PrintName();
                p.PrintEmail();


            }



            

            
            bool addBot = false;


            while (!addBot)
            {
                Console.WriteLine("\n\n ======================================");
                Console.WriteLine("if you wont to add BOT to list click y");
                if (Console.ReadLine().ToLower() == "y")
                {
                    Bot bot = new();
                    Console.WriteLine("   enter name");
                    bot.Name = Console.ReadLine();
                   
                    players.Add(bot);


                }
                else
                {
                    addBot = true;
                    Console.WriteLine("no more bots to add \n \n");

                }

            }

            Console.WriteLine(players.Count);


            string path = @"../../../records.txt";
           
          

           // StreamWriter sw = new StreamWriter(path);
            StreamWriter sw = File.CreateText(path);
            sw.WriteLine("{");

            foreach (BaseUnit p in players)
            {
                    
               if (p.GetType()== typeof(Player)) 
                { var player = (Player)p;
                  
                    player.PrintInfo();
                    Console.WriteLine(player.addtoJSON());
                   sw.WriteLine(player.addtoJSON());
                }

                if (p.GetType() == typeof(Bot))
                {
                    var bot = (Bot)p;
                    bot.PrintInfo();
                    
                    Console.WriteLine(bot.addtoJSON());
                    sw.WriteLine(bot.addtoJSON());

                }


            }
           // sw.WriteLine(JsonConvert.SerializeObject(players));
            sw.WriteLine("}");
            sw.Close();
            Console.ReadLine();

        }
    }
}
