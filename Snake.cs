using System;
using System.Linq;

namespace Snake
{
	class Snake : Figure
	{
		Direction dir;
		Direction notAvailable;
		public Snake(Point tail, int length, Direction dir)
		{
			if (length < 1)
				throw new ArgumentOutOfRangeException("Length Must Be Positive Number");
			this.dir = dir;
			for (int i = 0; i < length; i++)
			{
				var p = new Point(tail);
				p.Move(i, dir);
				points.Add(p);
			}
		}
		public bool IsEatSelf() => IsHit(GetNextPoint());
		public bool IsEatWall(Walls walls) => walls.IsHit(this);
		public bool IsEatFoot(Point f)
		{
			var next = GetNextPoint();
			if (next.IsHit(f))
			{
				points.Add(next);
				return true;
			}
			return false;
		}
		public void Move()
		{
			var t = points.First();
			var h = GetNextPoint();
			points.RemoveAt(0);
			points.Add(h);
			t.Clear();
			h.Draw();
			notAvailable = (Direction)(((int)dir + 2) % 4);
		}
		public void HandleKey(ConsoleKey key)
		{
			switch (key)
			{
				case ConsoleKey.LeftArrow:
				case ConsoleKey.A:
					if (notAvailable != Direction.LEFT)
						dir = Direction.LEFT;
					break;
				case ConsoleKey.UpArrow:
				case ConsoleKey.W:
					if (notAvailable != Direction.UP)
						dir = Direction.UP;
					break;
				case ConsoleKey.RightArrow:
				case ConsoleKey.D:
					if (notAvailable != Direction.RIGHT)
						dir = Direction.RIGHT;
					break;
				case ConsoleKey.DownArrow:
				case ConsoleKey.S:
					if (notAvailable != Direction.DOWN)
						dir = Direction.DOWN;
					break;
			}
		}
		private Point GetNextPoint()
		{
			var p = new Point(points.Last());
			p.Move(1, dir);
			return p;
		}
	}
}