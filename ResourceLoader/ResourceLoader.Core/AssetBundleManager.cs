using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Tommy;

namespace ResourceLoader.Core
{
    public class AssetBundleManager
    {
        private Dictionary<Manifest, AssetBundleCreateRequest>  _registeredBundles;
        private Dictionary<Manifest, AssetBundleRequest>        _loadingBundles;
        private Dictionary<Manifest, AssetBundle>               _loadedBundles;

        public AssetBundleManager()
        {
            _registeredBundles = new Dictionary<Manifest, AssetBundleCreateRequest>();
            _loadingBundles = new Dictionary<Manifest, AssetBundleRequest>();
            _loadedBundles = new Dictionary<Manifest, AssetBundle>();
        }

        public void RegisterBundle(Manifest manifest)
        {
            _registeredBundles.Add(manifest, AssetBundle.LoadFromFileAsync(manifest.Path));
        }
        
        // public GameObject GetAssetFromBundle(string guid, string assetName)
    }
}