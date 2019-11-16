using System;
using System.IO;
using System.Collections.Generic;
using System.Linq; //seda on vaja, et ToListiks muuta

namespace _14._11._19_listof_objects
{
	class Program
	{
		static void Main(string[] args)
		{
			string filePath = @"C:\Demo\items.txt";
			//selleks loon listi
			List<string> lines = File.ReadAllLines(filePath).ToList();
			//kuidas ma selle listi nüüd kuvan

			foreach (string line in lines)
			{
				Console.WriteLine($"{line}");
			}
			Console.ReadLine();

			}
	}
}
