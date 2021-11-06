using System;
using System.Collections.Generic;

namespace ResourceLoader.Core
{
    [Serializable]
    public struct AssetManifest
    {
        public string       Type   { get; set; }
        public string       Target { get; set; }
        public List<string> Files { get; set; }
    }
}