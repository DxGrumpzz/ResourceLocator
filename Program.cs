using System;
using System.Reflection;

namespace ResourceLocator
{
    /// <summary>
    /// A resource locator that finds embedded resources in an application
    /// </summary>
    public class ResourceLocator
    {
        private Assembly _currentAssembly;

        /// <summary>
        /// Default constructor creates an assembly from the calling function
        /// </summary>
        public ResourceLocator() : this(Assembly.GetCallingAssembly())
        {
        }

        public ResourceLocator(Assembly assembly)
        {
            _currentAssembly = assembly;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


    }
}
