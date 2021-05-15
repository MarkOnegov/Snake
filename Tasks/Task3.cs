using System;

namespace Snake.Tasks
{
	class Task3 : Task
	{
		public Task3()
		{
			Name = "IsHit";
			Index = 3;
		}
		public override void Start()
		{
			var p1 = new Point(0, 0);
			var p2 = new Point(p1);
			p1.Draw();
			Console.WriteLine();
			Console.WriteLine("Point p1 = new Point(0,0);");
			Console.WriteLine("Point p2 = new Point(p1);");
			Console.WriteLine("IsHit(p1,p2): {0}", Point.IsHit(p1, p2));
			Console.WriteLine("p1.IsHit(p2): {0}", p1.IsHit(p2));
			Console.WriteLine("p2.IsHit(p1): {0}", p2.IsHit(p1));
			Console.WriteLine("Equals(p1,p2): {0}", Equals(p1, p2));
			p2.Y = p1.Y = 10;
			p2.X = 1;
			p2.Char = '#';

			Console.WriteLine("p2.Y = p1.Y = 10;");
			Console.WriteLine("p2.X = 1;");
			Console.WriteLine("p2.Char = '#';");
			p1.Draw();
			p2.Draw();
			Console.WriteLine();
			Console.WriteLine("IsHit(p1,p2): {0}", Point.IsHit(p1, p2));
			Console.WriteLine("p1.IsHit(p2): {0}", p1.IsHit(p2));
			Console.WriteLine("p2.IsHit(p1): {0}", p2.IsHit(p1));
			Console.WriteLine();
			var f1 = new VerticalLine(20, 24, 2, '*');
			var f2 = new HorizontalLine(0, 4, 22, '*');
			Console.SetCursorPosition(0, 25);
			Console.WriteLine("Figure f1 = new VerticalLine(20, 24, 2, '*');");
			Console.WriteLine("Figure f2 = new HorizontalLine(0, 4, 22, '*');");
			Console.WriteLine("IsHit(f1, f2): {0}", Figure.IsHit(f1, f2));
			Console.WriteLine("f1.IsHit(f2): {0}", f1.IsHit(f2));
			Console.WriteLine("f2.IsHit(f1): {0}", f2.IsHit(f1));
			f1.Draw();
			f2.Draw();
			Console.ReadKey();
		}
	}
}
