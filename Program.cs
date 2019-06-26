using System;
using System.IO;
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
        /// Default constructor. Creates a default assembly from the calling function
        /// </summary>
        public ResourceLocator() : 
            this(Assembly.GetCallingAssembly())
        {
        }

        public ResourceLocator(Assembly assembly)
        {
            _currentAssembly = assembly;
        }


        #region Public functions

        public ManifestResourceInfo FindResource(string resourceName)
        {
            ManifestResourceInfo resource = _currentAssembly.GetManifestResourceInfo(resourceName);

            return resource;
        }

        #endregion
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
