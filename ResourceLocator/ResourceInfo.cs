namespace ResourceLocator
{
    using System.IO;

    /// <summary>
    /// A class that contains information about an embedded resource
    /// </summary>
    public class ResourceInfo
    {
        #region Public properties

        public string ResourceName { get; set; }
        public Stream ResourceStream { get; set; }
        public string ResourceFullname { get; set; }

        #endregion



        #region Public methods

        /// <summary>
        /// Returns the Resource's data Stream to a byte array
        /// </summary>
        /// <returns></returns>
        public byte[] ToByteArray()
        {
            // Validation
            if (ResourceStream is null)
                return null;

            // Holds the Resource's data stream 
            MemoryStream memoryStream = new MemoryStream();

            // Copy resource stream data to the memory stream
            ResourceStream.CopyTo(memoryStream);


            return memoryStream.ToArray();
        }

        #endregion
    }
}
