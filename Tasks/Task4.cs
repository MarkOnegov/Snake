using System;

namespace Snake.Tasks
{
	class Task4 : Task
	{
		public Task4()
		{
			Name = "Walls";
			Index = 4;
		}
		public override void Start()
		{
			new Walls(Console.WindowWidth, Console.WindowHeight).Draw();
			Console.ReadKey();
		}
	}
}
