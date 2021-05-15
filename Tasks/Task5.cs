using System;
using System.Threading;

namespace Snake.Tasks
{
	class Task5 : Task
	{
		public Task5()
		{
			Name = "Snake";
			Index = 5;
		}
		public override void Start()
		{
			new Walls(Console.WindowWidth, Console.WindowHeight).Draw();
			var snake = new Snake(new Point(4, 5, '*'), 4, Direction.RIGHT);
			snake.Draw();
			while (true)
			{
				if (Console.KeyAvailable)
				{
					Console.ReadKey();
					return;
				}
				snake.Move();
				Thread.Sleep(100);
			}
		}
	}
}
