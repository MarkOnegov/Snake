using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
	class Program
	{
		static Tasks.Task Select(List<Tasks.Task> tasks)
		{
			Console.WriteLine("Выберите задачу:");
			tasks.ForEach(t =>
			{ Console.WriteLine("{0})\t{1}", t.Index, t.Name); });
			Console.WriteLine("0)\tВыход");
			while (true)
			{
				try
				{
					var index = Convert.ToInt32(Console.ReadLine());
					if (index == 0) return null;
					var task = tasks.Where(t => t.Index == index).ToList();
					if (task.Count == 1) return task[0];
					throw new ArgumentOutOfRangeException();
				}
				catch { Console.WriteLine("Ошибка ввода. Попробуйте ещё раз"); }
			}
		}
		static void Main()
		{
			var tasks = typeof(Tasks.Task).Assembly.GetTypes()
				.Where(type => type.IsSubclassOf(typeof(Tasks.Task)) && !type.IsAbstract)
				.Select(type => (Tasks.Task)Activator.CreateInstance(type))
				.ToList();
			tasks.Sort((t1, t2) => t1.Index - t2.Index);
			while (true)
			{
				Console.Clear();
				Tasks.Task task = Select(tasks);
				Console.Clear();
				if (task == null) return;
				try { task.Start(); }
				catch (Exception e)
				{
					Console.Clear();
					Console.WriteLine(e);
					Console.ReadKey();
				}

			}
		}
	}
}
