namespace ResourceLocator
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.IO;
    using System.Text;

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
            Stream resourceStream = _currentAssembly.GetManifestResourceStream(foundResource);


            return new ResourceInfo()
            {
                ResourceName = resourceName,
                ResourceStream = resourceStream,
                ResourceFullname = FormatResourceFullname(foundResource),
            };
        }


        /// <summary>
        /// Finds embedded resources by name. Returns a list of matching results
        /// </summary>
        /// <param name="resourceNames"> The name of the resource </param>
        /// <returns> Returns an <see cref="IEnumerable{T}"/> that contains ResourceInfo </returns>
        public IEnumerable<ResourceInfo> FindResources(IEnumerable<string> resourceNames)
        {
            var foundResources = _resourceNames.
            // Finds matching resource names in current assembly 
            Where(new Func<string, int, bool>((_resourceName, _indexer) =>
            {
                _resourceName.Contains(resourceNames.ElementAt(_indexer));
                return true;
            }));


            int indexer = 0;
            foreach (string _resourceName in foundResources)
            {
                // Gets the resource's data stream
                Stream resourceStream = _currentAssembly.GetManifestResourceStream(_resourceName);

                yield return new ResourceInfo()
                {
                    ResourceName = resourceNames.ElementAt(indexer),
                    ResourceStream = resourceStream,
                    ResourceFullname = FormatResourceFullname(_resourceName),
                };

                indexer++;
            };
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Returns a new string containing a formatted resource name instead of '.' it will change to '\'
        /// </summary>
        /// <param name="resourceFullname"> </param>
        /// <returns></returns>
        private string FormatResourceFullname(string resourceFullname)
        {
            StringBuilder stringBuilder = new StringBuilder(resourceFullname);

            var projectName = _currentAssembly.GetName().Name;

            // Replace characters
            stringBuilder.Remove(0, projectName.Length);
            stringBuilder.Replace('.', '\\');

            return stringBuilder.ToString();
        }

        #endregion
    }
}
