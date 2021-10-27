using System;
using System.Collections.Generic;

namespace ResourceLoader.Core
{
    [Serializable]
    public class ResourceManifest
    {
        public string              Name   { get; set; }
        public string              GUID   { get; set; }
        public List<AssetManifest> Assets { get; set; }
        
        public ResourceManifest() {}
        
    }
}