using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FinalTask_13._1
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = "Text.txt";
			if (!File.Exists(path))
			{
				Console.WriteLine("Файл не нашёлся");
				return;
			}
			string[] book = File.ReadAllLines(path);

			var watchOne = Stopwatch.StartNew();
			List<string> listBook = new List<string>(book);
			Console.WriteLine($"Загрузка из файла в List: {watchOne.Elapsed.TotalMilliseconds}  мс");

			var watchTwo = Stopwatch.StartNew();
			LinkedList<string> llistBook = new LinkedList<string>(book);
			Console.WriteLine($"Загрузка из файла в LinkedList: {watchTwo.Elapsed.TotalMilliseconds}  мс");
			
			Console.WriteLine();
			
			watchOne = Stopwatch.StartNew();
			int i = listBook.IndexOf(listBook.Find(x => x == "Часть четвертая"));
			Console.WriteLine($"поиск строки \"Часть четвертая\" в List: {watchOne.Elapsed.TotalMilliseconds}  мс");
			watchOne = Stopwatch.StartNew();
			listBook.Insert(++i, "(заключительная)");
			Console.WriteLine($"вставка после неё строки \"(заключительная)\": {watchOne.Elapsed.TotalMilliseconds}  мс");

			Console.WriteLine();

			LinkedListNode<string> item;
			watchTwo = Stopwatch.StartNew();
			item = llistBook.Find("Часть четвертая");
			Console.WriteLine($"поиск строки \"Часть четвертая\" в LinkedList: {watchTwo.Elapsed.TotalMilliseconds}  мс");
			watchTwo = Stopwatch.StartNew();
			llistBook.AddAfter(item, "(заключительная)");
			Console.WriteLine($"вставка после неё строки \"(заключительная)\": {watchTwo.Elapsed.TotalMilliseconds}  мс");

		}
	}
}
