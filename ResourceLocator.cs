namespace ResourceLocator
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;


    /// <summary>
    /// A resource locator that finds embedded resources in an application
    /// </summary>
    public class ResourceLocator
    {
        private Assembly _currentAssembly;

        /// <summary>
        /// Default constructor. Creates a default assembly from the currently executing code
        /// </summary>
        public ResourceLocator() :
            this(Assembly.GetExecutingAssembly())
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
}
