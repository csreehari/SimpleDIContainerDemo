using System;
using SimpleDIDemo.Interfaces;

namespace SimpleDIDemo
{
	public class ClassA : IInterfaceA
	{
		public ClassA()
		{
		}

        public void DoWorkA()
        {
            Console.WriteLine("Do Work A");
        }
    }
}

