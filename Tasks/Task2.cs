using System;

namespace Snake.Tasks
{
	class Task2 : Task
	{
		public Task2()
		{
			Name = "Figures";
			Index = 2;
		}
		public override void Start()
		{
			new HorizontalLine(0, 10, 0, '*').Draw();
			new HorizontalLine(0, 10, 5, '*').Draw();
			new VerticalLine(1, 5, 0, '*').Draw();
			new VerticalLine(1, 5, 10, '*').Draw();
			Console.ReadKey();
		}
	}
}
