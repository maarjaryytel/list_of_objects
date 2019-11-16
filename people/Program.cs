using System;
using System.IO;
using System.Collections.Generic;
using System.Linq; //seda on vaja, et ToListiks muuta

namespace _14._11._19_listof_objects
{

	//iga inimene on klass ja iga isik on selle klassi esindaja ja objektil on 3 omadust- ees- ja perenimi ja vanus
	//loon klassi inimene

	class Person
	{
		//mis on selle klassi sees- nimed ja vanus
		public static int Count = 0; //see on klassi omadus

		public string firstName; //see on objekti omadus
		public string lastName;
		public int age;
		
		public Person(string _firstName, string _lastName, int _age)
		//kuidas ma annan arvutile teada mis need väärtused on
		{
			firstName = _firstName;
			lastName = _lastName;
			age = _age;
			//kuidas ma loen need inimesed kokku- public static int count- üleval

			//loome iga inimese jaoks eraldi rea
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			string filePath = @"C:\Demo\people.txt";
			//list mis loeb maha
			List<string> listOfPeople = File.ReadAllLines(filePath).ToList(); //filepath- st kust ta võtab faili

			//teine list on list nendest inimestest
			List<Person> listOfPersonObjects = new List<Person>();
			
			//peame need isikud maha lugema
					   
			foreach (string line in listOfPeople)
			{
				//kui ma tahan neid andmeid kasutada pean neid eraldi massiivi salvestama

				string[] tempArray = line.Split(new char[] { ',',' ' },StringSplitOptions.RemoveEmptyEntries);
				//tempArray- ajutine massiiv üksnes lugemiseks

				//loome objekti
				Person newPerson = new Person(tempArray[0], tempArray[1], int.Parse(tempArray[2])); //hakkamme seda massiivi lahti kirjutama
		      	//kuidas ma lisan listi sisse, siis ta salvestab selle objekti
				listOfPersonObjects.Add(newPerson);
								
			}
			//kuidas ma saaks veenduda, et kas on midagi salvestatud

			//mis tüüpi andmed on- ei ole sõnad, on objektid

			foreach (Person person in listOfPersonObjects)
			{
				Console.WriteLine($"{person.firstName} {person.lastName} age {person.age}, is on your list.");
			}
		

			Console.ReadLine();

			
		}
	}
}

