using System;
using System.Collections.Generic;
using Tommy;

namespace ResourceLoader.Core
{
    [Serializable]
    public class Manifest
    {
        public string       GUID              { get; set; }
        public string       Path              { get; set; }
        public List<string> AssetReplacements { get; set; }

        public Manifest()
        {
            GUID = String.Empty;
            Path = String.Empty;
            AssetReplacements = new List<string>();
        }

        public Manifest(TomlTable table)
        {
            GUID = table["GUID"].AsString.Value;
            Path = table["Path"].AsString.Value;
            AssetReplacements = new List<string>();
            foreach (TomlNode node in table["AssetReplacements"].Children)
            {
                AssetReplacements.Add(node.AsString.Value);
            }
        }
    }
}