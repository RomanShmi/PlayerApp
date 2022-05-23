using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Bot : BaseUnit
    {

        /// <summary>
        /// Refer to PlayerExt
        /// </summary>
        public delegate void PrintBotInfo(Bot b);


        /// <summary>
        /// Accepts a print method and a Player to be printed
        /// </summary>
        /// <param name="printPlayer"></param>
        /// <param name="bot"></param>
        public void Print(PrintBotInfo printPlayer, Bot bot)
        {
            printPlayer(bot);
        }

        public override void PrintInfo()
        {
            Console.WriteLine("BOT  ===========> "+this.Id + "  " + this.Name);
        }
    public override string addtoJSON() 
        {
            return JsonConvert.SerializeObject(this);

        }
    
    
    
    
    
    
    
    
    
    }
}
