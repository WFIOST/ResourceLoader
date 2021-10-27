using System.Collections;
using System.Collections.Generic;
using System.IO;
using BepInEx;
using Stratum;
using Stratum.Extensions;

namespace ResourceLoader.Core
{
    [BepInPlugin(PluginDescriptor.GUID, PluginDescriptor.NAME, PluginDescriptor.VERSION)]
    public class Plugin : StratumPlugin
    {
        public static Plugin Instance { get; private set; }
        
        public Dictionary<string, IAssetLoader> Loaders  { get; }

        public Plugin()
        {
            Loaders = new Dictionary<string, IAssetLoader>();
            Logger.LogInfo("Started ResourceLoader!");
            Instance = this;
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
    }
}