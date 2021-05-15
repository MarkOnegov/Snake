using System.Collections.Generic;
using System.Linq;

namespace Snake
{
	class Figure
	{
		protected List<Point> points = new List<Point>();
		public void Draw() => points.ForEach(p => p.Draw());
		public bool IsHit(Point p) => IsHit(this, p);
		public bool IsHit(Figure f) => IsHit(this, f);
		public static bool IsHit(Figure f, Point p) => f.points.Any(p1 => Point.IsHit(p1, p));
		public static bool IsHit(Figure f1, Figure f2) => f1.points.Any(p => IsHit(f2, p));
	}
	class VerticalLine : Figure
	{
		public VerticalLine(int up, int down, int x, char _char)
		{
			for (int i = up; i <= down; i++)
				points.Add(new Point(x, i, _char));
		}
	}
	class HorizontalLine : Figure
	{
		public HorizontalLine(int left, int right, int y, char _char)
		{
			for (int i = left; i <= right; i++)
				points.Add(new Point(i, y, _char));
		}
	}
}
