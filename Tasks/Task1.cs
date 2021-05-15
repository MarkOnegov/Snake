using System;

namespace Snake.Tasks
{
	class Task1 : Task
	{
		public Task1()
		{
			Name = "Class Point";
			Index = 1;
		}
		public override void Start()
		{
			var s =
				"----\n" +
				" ##--\n" +
				"----";
			var strings = s.Split('\n');
			for (var i = 0; i < strings.Length; i++)
			{
				var ss = strings[i];
				for (var j = 0; j < ss.Length; j++)
					new Point() { X = j, Y = i, Char = ss[j] }.Draw();
			}
			Console.ReadKey();
		}
	}
}
