using System.Collections;
using System.Collections.Generic;
using System.IO;
using BepInEx.Logging;

namespace ResourceLoader.Core
{
    public interface IAssetLoader
    {
        public ManualLogSource            Logger       { get; set; }
        public IEnumerable<AssetManifest> LoadedAssets { get; set; }

        public IEnumerator LoadAsset(AssetManifest manifest);
    }
}