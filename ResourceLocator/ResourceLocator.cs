namespace ResourceLocator
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using System.Linq;
    using System.IO;

    /// <summary>
    /// A resource locator that finds embedded resources in an application
    /// </summary>
    public class ResourceLocator
    {
    
        #region Private fields

        /// <summary>
        /// The current assemlby, Where the resources are located
        /// </summary>
        private Assembly _currentAssembly;

        /// <summary>
        /// Names of resources in the current assembly
        /// </summary>
        private IEnumerable<string> _resourceNames;

        #endregion


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
            _resourceNames = assembly.GetManifestResourceNames();
        }



        #region Public functions

        /// <summary>
        /// Finds an embedded resource by name. Returns the first match it finds
        /// </summary>
        /// <param name="resourceName"> The name of the resource </param>
        /// <returns></returns>
        public ResourceInfo FindResource(string resourceName)
        {
            var foundResource = _resourceNames.
                // Finds the first match, Return null or default if no match was found
                FirstOrDefault(_resourceName => _resourceName.Contains(resourceName));

            // Gets the resource's data stream
            Stream resourceStream  = _currentAssembly.GetManifestResourceStream(foundResource);


            return new ResourceInfo()
            {
                ResourceName = resourceName,
                ResourceStream = resourceStream,
            };
        }

        #endregion
    }
}
