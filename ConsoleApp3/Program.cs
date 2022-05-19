using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp4
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
           Player p1= new();
            p1.Name = "AAAAAAAAA";
            p1.Email = "asdf@asd.dd";
            Console.WriteLine(p1.Id+"  "+p1.Name+" "+p1.Email);


            List < Player > players= new List<Player>();
           
            
            players.Add(p1);

            bool addPlayer = false;

            
            while (!addPlayer)
            {
                Console.WriteLine("if you wont to add player to list click y");
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



        }
    }
}
