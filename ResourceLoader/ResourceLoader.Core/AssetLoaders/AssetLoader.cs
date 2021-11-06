using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BepInEx.Logging;

namespace ResourceLoader.Core
{
    public abstract class AssetLoader 
    {
        public ManualLogSource Logger { get; set; }
        public abstract IEnumerator LoadAsset(AssetManifest manifest);
        public abstract void ReplaceAsset(GameObject spawnedObject);
    }
    public abstract class AssetLoader<TAsset> : AssetLoader
    {
        public Dictionary<AssetManifest, TAsset> LoadedAssets { get; set; }
    }
}