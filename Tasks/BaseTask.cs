namespace Snake.Tasks
{
	abstract class Task
	{
		public string Name { get; set; }
		public int Index { get; set; }
		public abstract void Start();
	}
}