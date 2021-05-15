using System.Collections.Generic;
using System.Linq;

namespace Snake
{
	class Walls
	{
		readonly List<Figure> walls = new List<Figure>();
		public Walls(int width, int height)
		{
			walls.Add(new HorizontalLine(0, width - 2, 0, '+'));
			walls.Add(new HorizontalLine(0, width - 2, height - 1, '+'));
			walls.Add(new VerticalLine(0, height - 1, 0, '+'));
			walls.Add(new VerticalLine(0, height - 1, width - 2, '+'));
		}
		public bool IsHit(Figure f) => IsHit(this, f);
		public bool IsHit(Point p) => IsHit(this, p);
		public void Draw() => walls.ForEach(f => f.Draw());
		public static bool IsHit(Walls w, Figure f) => w.walls.Any(f1 => Figure.IsHit(f1, f));
		public static bool IsHit(Walls w, Point p) => w.walls.Any(f => Figure.IsHit(f, p));

	}
}
