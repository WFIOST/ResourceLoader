using System.Linq;
using System;
using System.Collections.Generic;
using ResourceLoader.Common;
using Tommy;

namespace ResourceLoader.Core
{
    [Serializable]
    public class ResourceManifest
    {
        public string              Name   { get; set; }
        public string              Guid   { get; set; }
        public List<AssetManifest> Assets { get; set; }
        
        public ResourceManifest() {}
        public ResourceManifest(TomlTable rootTable)
        {
            Name = rootTable["Name"];
            Guid = rootTable["GUID"];
            Assets = new List<AssetManifest>();
            foreach (TomlNode asset in rootTable["Assets"].AsArray)
            {
                var manifest = new AssetManifest()
                {
                    Type = asset["Type"],
                    Target = asset["Target"],
                    Files = new List<AssetFile>()
                };

                foreach (TomlNode file in asset["Files"].AsArray)
                {
                    var assetfile = new AssetFile()
                    {
                        Path = file["Path"],
                        Attributes = new List<string>()
                    };

                    foreach (TomlNode attrib in file["Attributes"].AsArray)
                    {
                        assetfile.Attributes.Add(attrib);
                    }
                }

                Assets.Add(manifest);
            }
        }
    }
}