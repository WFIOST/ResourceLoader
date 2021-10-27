using System;
using System.Collections.Generic;
using BepInEx.Logging;
using UnityEngine;

namespace ResourceLoader.Core
{
    public static class ResourceRedirector
    {
        public static Dictionary<string, IAssetLoader>        AvailableResourceLoaders { get; }
        public static Dictionary<AssetManifest, IAssetLoader> ActiveResourceLoaders    { get; }

        static ResourceRedirector()
        {
            AvailableResourceLoaders = new Dictionary<string, IAssetLoader>();
            ActiveResourceLoaders = new Dictionary<AssetManifest, IAssetLoader>();
        }

        public static void LoadResource(ResourceManifest resource)
        {
            foreach (AssetManifest asset in resource.Assets)
            {
                IAssetLoader loader;
                try
                {
                    loader = AvailableResourceLoaders[asset.Type];
                }
                catch (KeyNotFoundException exception)
                {
                    throw new KeyNotFoundException($"Could not find loader for asset type {asset.Type}!");
                }
                
                loader.Logger = new ManualLogSource($"({resource.GUID}) {asset.Type} Asset Loader");
                Plugin.Instance.StartCoroutine(loader.LoadAsset(asset));
                ActiveResourceLoaders.Add(asset, loader);
            }
        }
    }
}