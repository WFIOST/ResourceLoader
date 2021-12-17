using System.Collections;
using System.IO;
using BepInEx;
using Stratum;
using Tommy;

namespace ResourceLoader.Core
{
    [BepInPlugin(PluginDescriptor.GUID, PluginDescriptor.NAME, PluginDescriptor.VERSION)]
    public class Plugin : StratumPlugin
    {
        public static Plugin             Instance           { get; private set; }
        public        AssetBundleManager AssetBundleManager { get; }

        public Plugin()
        {
            Logger.LogInfo("Started ResourceLoader!");
            AssetBundleManager = new AssetBundleManager();
            Instance = this;
        }

        public override void OnSetup(IStageContext<Empty> ctx)
        {
            ctx.Loaders["prefabReplacement"] = (file) =>
            {
                AssetBundleManager.RegisterBundle(new Manifest(TOML.Parse(new StreamReader(File.OpenRead(file.FullName)))));
                return new Empty();
            };
        }

        public override IEnumerator OnRuntime(IStageContext<IEnumerator> ctx)
        {
            yield return null;
        }
    }
}