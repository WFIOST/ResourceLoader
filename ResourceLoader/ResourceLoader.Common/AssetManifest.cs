using System;
using System.Collections.Generic;

namespace ResourceLoader.Common
{
    [Serializable]
    public struct AssetFile
    {
        public string           Path       { get; set; }
        public List<string>?    Attributes { get; set; }
    }
    [Serializable]
    public struct AssetManifest
    {
        public string          Type   { get; set; }
        public string          Target { get; set; }
        public List<AssetFile> Files  { get; set; }
    }
}