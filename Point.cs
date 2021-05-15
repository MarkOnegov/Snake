using System;

namespace Snake
{
	class Point
	{
		private protected int x = 0;
		private protected int y = 0;
		private protected char _char = '*';
		public int X
		{
			get => x;
			set
			{
				if (value < 0 || value >= Console.BufferWidth)
					throw new ArgumentOutOfRangeException("X Must Be Non Negative Number And Less Buffer Width");
				x = value;
			}
		}
		public int Y
		{
			get => y;
			set
			{
				if (value < 0 || value >= Console.BufferHeight)
					throw new ArgumentOutOfRangeException("Y Must Be Non Negative Number And Less Buffer Height");
				y = value;
			}
		}
		public Point() { }
		public Point(Point p)
		{
			x = p.x;
			y = p.y;
			_char = p._char;
		}
		public Point(int x, int y, char _char)
		{
			this._char = _char;
			X = x;
			Y = y;
		}
		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}
		public char Char { get => _char; set => _char = value; }
		public void Draw() => Draw(x, y, _char);
		public void Draw(int x, int y) => Draw(x, y, _char);
		public void Draw(char _char) => Draw(x, y, _char);
		public bool IsHit(Point p) => IsHit(this, p);
		public void Clear() => Draw(' ');
		public void Move(int offset, Direction dir)
		{
			switch (dir)
			{
				case Direction.LEFT:
					X -= offset;
					break;
				case Direction.RIGHT:
					X += offset;
					break;
				case Direction.UP:
					Y -= offset;
					break;
				case Direction.DOWN:
					Y += offset;
					break;
				default:
					throw new ArgumentException("Not available direction");
			}
		}
		public static void Draw(int x, int y, char _char)
		{
			Console.SetCursorPosition(x, y);
			Console.Write(_char);
		}
		public static bool IsHit(Point p1, Point p2) => p1.x == p2.x && p1.y == p2.y;
	}
}