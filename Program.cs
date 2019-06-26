namespace ResourceLocator
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Linq;


    


    class Program
    {
        static void Main(string[] args)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            string resourceName = "DemoUserImage.png";



            Console.WriteLine("Hello World!");
        }
    }
}
