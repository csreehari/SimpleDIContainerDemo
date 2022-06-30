// See https://aka.ms/new-console-template for more information
using SimpleDIDemo;
using SimpleDIDemo.Interfaces;

Console.WriteLine("Simple DI Demo!");

DIContainer container = new DIContainer();
container.Register<IInterfaceA, ClassA>();
container.Register<IInterfaceB, ClassB>();

IInterfaceB classB = container.Resolve<IInterfaceB>();
classB.DoWorkB();

Console.ReadKey();


