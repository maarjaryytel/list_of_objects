using System;
using System.IO;
using System.Collections.Generic;
using System.Linq; //seda oli vaja, et saaks massiivi listiks muuta

namespace TaskList
{
	class Task
	{
		public static int Count; //static- saab kätte üle klassi
		public string description;

		public Task(string _description)
		
		{
			description = _description;
			Count++;
		}

	}
	class Program
	{
		static void Main(string[] args)
		{
			//tahaks seda faili lugeda
			string filePath = @"C:\Demo\tasklist.txt";

			//kuidas loen andmeid maha- listiga
			List<string> lines = File.ReadAllLines(filePath).ToList();
			
			//olen maha lugenud, kuidas ma veendun, et need on mul olemas
			//foreachiga veendun, see on kontrollimiseks

			/*foreach (string line in lines)
			{
				Console.WriteLine($"{line}");
			}*/
			
			//Tahan neid failis olevaid salvestada objektidena
			//salvestan neid listina

			List<Task> Tasklist = new List<Task>(); //nüüd see list on valmis

			//kuidas ma loon neid objektid ja salvestan- foreachiga

			foreach (string line in lines)
			{
				//splittida ei ole vaja
				//loon igast reast kui olen ta kätte saanud objekti
				//create a task object at each line that we read from the file
				Task newTask = new Task(line); //line on kirjeldus
				//kuidas ma loon kirjelduse sinna tasklisti juurde
				//add the object to the tasklist
				Tasklist.Add(newTask);
			}
			//kuidas ma saan seda kontrollida- foreachiga

			int i = 1; //hakkan lugema 1-st, võin siia panna mis numnbri mul vaja on

			foreach (Task task in Tasklist)
			{
				Console.WriteLine($"Task {i} on your TODO list is to {task.description}.");
				i++;
			}

			//kasutaja soovib veel midagi lisada

			Console.WriteLine("Add a new task: ");

			string userTaskInput = Console.ReadLine();//nüüd mul on sõna olemas

			//nüüd võin luua uue objekti- task
			Task userTask = new Task(userTaskInput); //objekt on loodud

			//kuidas lisan oma objektide listi
			// save the usertask to the Tasklist
			Tasklist.Add(userTask);

			//veendume kas see töötab

			Console.WriteLine("Updated task list: ");
			foreach (Task task in Tasklist)
			{
				Console.WriteLine($"Task {i} on your TODO list is to {task.description}.");
				i++;
			}

			//tahaks seda uuendatud listi lisada faili sisse, et kuvaks kohe 4 tegevust
			//loon eraldi listi kuhu salvestan ainult sõned
			//creat a new list of string to write to the file

			List<string> outputToWriteToFile = new List<string>();

			//iga ülesande jaoks mida olen salvestanud listi sisse
			//ma lisan sellesse listi ainult sõnede väärtused

			foreach (Task task in Tasklist)
			{
				outputToWriteToFile.Add($"{task.description}");
			}

			//write to outputToWriteToFile 
            Console.WriteLine("writing to a file: ");

			//selleks et salvestada uue faili sisse teeme järgmist
			File.WriteAllLines(filePath, outputToWriteToFile);
			Console.WriteLine("Your task has been added");

			Console.ReadLine();
		}
	}
}
