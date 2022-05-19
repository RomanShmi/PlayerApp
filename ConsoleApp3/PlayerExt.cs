using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
	/// <summary>
	/// Extends the Player Class with some print methods
	/// </summary>
	public static class PlayerExt
	{
		public static void PrintName(this Player pl)
		{

			Console.WriteLine($"Ext - Player name: {pl.Name}");
		}
		public static void PrintId(this Player pl)
		{
			Console.WriteLine($"Ext - Player id: {pl.Id}");
		}
		public static void PrintEmail(this Player pl)
		{
			Console.WriteLine($"Ext - Player email: {pl.Email}");
		}
		public static void PrintNameAndId(this Player pl)
		{
			Console.WriteLine($"Ext - Player name: {pl.Name}      Player Email {pl.Email}      Player id: {pl.Id}"); ;
		}
	}
}

