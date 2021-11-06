using System.Collections;
using System.Collections.Generic;
using System.IO;
using BepInEx;
using Stratum;
using Stratum.Extensions;
using ResourceLoader.Core.AssetLoaders;
using FistVR;

namespace ResourceLoader.Core
{
    [BepInPlugin(PluginDescriptor.GUID, PluginDescriptor.NAME, PluginDescriptor.VERSION)]
    public class Plugin : StratumPlugin
    {
        public static Plugin Instance { get; private set; }

        public Plugin()
        {
            Logger.LogInfo("Started ResourceLoader!");
            Instance = this;

            ResourceRedirector.AvailableResourceLoaders["Prefab"] = new PrefabAssetLoader();
            ResourceRedirector.AvailableResourceLoaders["Texture"] = new TextureAssetLoader();
        }

        public override void OnSetup(IStageContext<Empty> ctx)
        {
            ctx.Loaders.Add("resource", (fsinfo) =>
            {
                FileInfo manifestFile = fsinfo.ConsumeFile();
                
                return new Empty();
            });
        }

        public override IEnumerator OnRuntime(IStageContext<IEnumerator> ctx)
        {
            yield return null;
        }

        private void Awake()
        {
            On.FistVR.ItemSpawner.SpawnItem += ResourceRedirector.ReplaceAssets;
        }
    }
}