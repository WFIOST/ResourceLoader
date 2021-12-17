using System.Linq;
using System.Collections.Generic;
using System.Collections;
using ResourceLoader.Common;
using UnityEngine;
using BepInEx.Logging;

namespace ResourceLoader.Core.AssetLoaders
{
    public class AssetBundleAssetLoader : AssetLoader<AssetBundle>
    {
        private Dictionary<string, AssetBundleCreateRequest> _availableAssetBundles;

        public AssetBundleAssetLoader(ManualLogSource logger) : base(logger)
        {
            _availableAssetBundles = new Dictionary<string, AssetBundleCreateRequest>();
        }

        public override IEnumerator LoadAsset(AssetManifest manifest)
        {
            foreach (AssetFile file in manifest.Files)
            {
                _availableAssetBundles.Add(file.Path, AssetBundle.LoadFromFileAsync(file.Path));
                yield return null;
            }
        }

        public override void ReplaceAsset(AssetManifest manifest, GameObject _) 
        {
        
        }
    }
}