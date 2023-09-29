using System;

namespace Knuckle
{
	public class Log
	{
		public static void _Log(string level, string msg, ConsoleColor color, params object[] args)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("{0}", DateTime.Now.ToString("HH:mm:ss.ffff"));
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.Write(" [");
			Console.ForegroundColor = color;
			Console.Write("{0}", level);
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.Write("] ");
			Console.ForegroundColor = ConsoleColor.White;
			msg = String.Format(msg, args);
			Console.WriteLine(msg);
		}
		public static void Info(string msg, params object[] args)
        {
            Knuckle.Log._Log(" INFO", msg, ConsoleColor.Blue, args);
		}

		public static void Error(string msg, params object[] args)
		{
			Knuckle.Log._Log("ERROR", msg, ConsoleColor.Red, args);
		}
	}
}
