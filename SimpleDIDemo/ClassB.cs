using System;
using SimpleDIDemo.Interfaces;

namespace SimpleDIDemo
{
	public class ClassB : IInterfaceB
	{
        private readonly IInterfaceA _classA;

        public ClassB(IInterfaceA classA)
		{
            _classA = classA;
		}

        public void DoWorkB()
        {
            _classA.DoWorkA();
            Console.WriteLine("Do Work B");
        }
    }
}

