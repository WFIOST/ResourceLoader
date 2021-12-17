using System.Collections.Generic;
using BepInEx.Logging;
using FistVR;
using ResourceLoader.Common;
using ResourceLoader.Core.AssetLoaders;

namespace ResourceLoader.Core.Resource
{
    public static class ResourceRedirector
    {
        public static Dictionary<string, AssetLoader>        AvailableResourceLoaders { get; }
        public static Dictionary<AssetManifest, AssetLoader> ActiveResourceLoaders    { get; }

        static ResourceRedirector()
        {
            AvailableResourceLoaders = new Dictionary<string, AssetLoader>();
            ActiveResourceLoaders = new Dictionary<AssetManifest, AssetLoader>();
        }

        public static void LoadResource(ResourceManifest resource)
        {
            foreach (AssetManifest asset in resource.Assets)
            {
                AssetLoader loader;
                try
                {
                    loader = AvailableResourceLoaders[asset.Type];
                }
                catch (KeyNotFoundException)
                {
                    throw new KeyNotFoundException($"Could not find loader for asset type {asset.Type}!");
                }
                
                loader.Logger = new ManualLogSource($"({resource.Guid}) {asset.Type} Asset Loader");
                Plugin.Instance.StartCoroutine(loader.LoadAsset(asset));
                ActiveResourceLoaders.Add(asset, loader);
            }
        }

        public static void ReplaceAssets(On.FistVR.ItemSpawner.orig_SpawnItem _, ItemSpawner @this)
        {
            foreach (var loader in ActiveResourceLoaders)
            {
                if (@this.Definitions[@this.CurrentItemIndex[@this.CurrentCategory]])
                {
                    
                }
            }
        }
    }
}