namespace ResourceLocator
{
    using System.IO;

    /// <summary>
    /// A class that contains information about an embedded resource
    /// </summary>
    public class ResourceInfo
    {

        public string ResourceName { get; set; }
        public Stream ResourceStream { get; set; }

    }
}
