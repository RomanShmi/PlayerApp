using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using Newtonsoft.Json;

namespace ConsoleApp4
{
    public class Player : BaseUnit, IPlayer
    {
         private string _email = "";
          public string Email { get { return _email; } set {

                do
                {
                   
                    if (!IsValidEmail(value))
                    {
                        Console.WriteLine("enter correct email");
                        _email = Console.ReadLine(); 
                    
                    }
                else { _email= value; }
                
                
                }
                while (!IsValidEmail(_email));


            } }



        /// <summary>
        /// Refer to PlayerExt
        /// </summary>
        public delegate void PrintPlayerInfo(Player p);


        /// <summary>
        /// Validate email adress return true if correct
        /// </summary>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }


        /// <summary>
        /// Print Player info
        /// </summary>
        public override void PrintInfo() 
        {
            Console.WriteLine("PLAYER ============> "+this.Id + "  " + this.Name + " " + this.Email);
        }

        /// <summary>
        /// Accepts a print method and a Player to be printed
        /// </summary>
        /// <param name="printPlayer"></param>
        /// <param name="player"></param>
        public void Print(PrintPlayerInfo printPlayer, Player player)
        {
            printPlayer(player);
        }

        public override string addtoJSON()
        {
            return JsonConvert.SerializeObject(this);

        }





    }
}
