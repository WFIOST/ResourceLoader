using BepInEx;

namespace ResourceLoader.Core
{
    [BepInPlugin(PluginDescriptor.GUID, PluginDescriptor.NAME, PluginDescriptor.VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public Plugin()
        {
            Logger.LogInfo("Started ResourceLoader!");
        }
    }
}