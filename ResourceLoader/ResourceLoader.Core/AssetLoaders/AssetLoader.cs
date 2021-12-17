using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BepInEx.Logging;
using ResourceLoader.Common;


namespace ResourceLoader.Core.AssetLoaders
{
    public abstract class AssetLoader 
    {
        public ManualLogSource Logger { get; set; }
        public abstract IEnumerator LoadAsset(AssetManifest manifest);
        public abstract void ReplaceAsset(AssetManifest manifest, GameObject spawnedObject);

        public AssetLoader(ManualLogSource logger)
        {
            Logger = logger;
        }
    }
    public abstract class AssetLoader<TAsset> : AssetLoader
    {
        public Dictionary<AssetManifest, TAsset> LoadedAssets { get; set; }

        public AssetLoader(ManualLogSource logger) : base(logger)
        {
            LoadedAssets = new Dictionary<AssetManifest, TAsset>();
        }
    }
}