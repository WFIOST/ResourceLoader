using System.Collections;
using System.IO;
using BepInEx;
using Stratum;
using Stratum.Extensions;
using ResourceLoader.Core.AssetLoaders;
using ResourceLoader.Core.Resource;
using Tommy;
using ResourceLoader.Common;

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

            ResourceRedirector.AvailableResourceLoaders["AssetBundle"] = new AssetBundleAssetLoader(Logger);
            ResourceRedirector.AvailableResourceLoaders["Texture"] = new TextureAssetLoader(Logger);
        }

        public override void OnSetup(IStageContext<Empty> ctx)
        {
            ctx.Loaders.Add("resource", (fsinfo) =>
            {
                FileInfo manifestFile = fsinfo.ConsumeFile();

                ResourceManifest manifest;

                using (StreamReader reader = manifestFile.OpenText())
                {
                    TomlTable rootTable = TOML.Parse(reader);
                    manifest = new ResourceManifest(rootTable);
                }
                
                foreach (AssetManifest asset in manifest.Assets)
                {
                    ResourceRedirector.AvailableResourceLoaders[asset.Type].LoadAsset(asset);
                }

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