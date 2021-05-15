using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake.Tasks
{
	class Task6 : Task
	{
		private readonly Random random = new Random();
		private readonly int width = 25;
		private readonly int height = 25;
		private readonly int dt = 100;
		private int score;
		private Walls walls;
		private Snake snake;
		public Task6()
		{
			Name = "Let's play (:";
			Index = 6;
		}
		public override void Start()
		{
			Console.CursorVisible = false;
			walls = new Walls(width, height);
			walls.Draw();

			snake = new Snake(new Point(5, 5), 4, Direction.RIGHT);
			snake.Draw();

			var food = GenerateFood();
			food.Draw();

			score = -1;
			UpdateScore();

			var lastUpdate = DateTime.Now;
			while (true)
			{
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo keyInfo = Console.ReadKey(true);
					if (keyInfo.Key == ConsoleKey.Escape) break;
					snake.HandleKey(keyInfo.Key);
				}
				if ((DateTime.Now - lastUpdate).TotalMilliseconds > dt)
				{
					lastUpdate = DateTime.Now;
					if (snake.IsEatFoot(food))
					{
						UpdateScore();
						food = GenerateFood();
						food.Draw();
					}
					else if (snake.IsEatSelf() || snake.IsEatWall(walls)) break;
					else snake.Move();
				}
			}
			GameOver();
			Console.CursorVisible = true;
			Console.ReadKey();
		}
		private void UpdateScore()
		{
			Console.SetCursorPosition(0, height + 1);
			Console.Write("Score: {0}", ++score);
		}
		private string[] GetStringsOfNum(byte num)
		{
			if (num > 9)
				throw new ArgumentOutOfRangeException("Num Must Be from 0 to 9");
			return Resources.ResourceManager.GetString(num.ToString()).Split('\n');
		}
		private void GameOver()
		{
			Console.Clear();
			Resources.GameOver.Split('\n').ToList().ForEach(s => Console.WriteLine(s));
			Resources.Score.Split('\n').ToList().ForEach(s => Console.WriteLine(s));
			PrintScore();
		}
		private Point GenerateFood()
		{
			while (true)
			{
				var x = 1 + random.Next(width - 3);
				var y = 1 + random.Next(height - 2);
				var food = new Point(x, y, '$');
				if (!walls.IsHit(food) && !snake.IsHit(food))
					return food;
			}
		}
		private void PrintScore()
		{
			var vs = new string[5];
			GetNums(score).ForEach(num =>
			{
				var t = GetStringsOfNum(num);
				for (int i = 0; i < 5; i++)
					vs[i] += t[i];
			});
			vs.ToList().ForEach(Console.WriteLine);
		}
		private List<byte> GetNums(int num)
		{
			if (num < 0)
				throw new ArgumentOutOfRangeException("Num Must Be Non Negative Number");
			var nums = new List<byte>();
			while (num > 0)
			{
				nums.Add((byte)(num % 10));
				num /= 10;
			}
			while (nums.Count < 4) nums.Add(0);
			nums.Reverse();
			return nums;
		}
	}
}