using System;
using System.Threading;

namespace TestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var wrote = false;
                Thread.Sleep(100);
                var keys = KeyHandler.KeyHandler.GetPressedKeys();
                foreach (var key in keys)
                {
                    Console.Write(key + " ");
                    wrote = true;
                }

                if (wrote)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}