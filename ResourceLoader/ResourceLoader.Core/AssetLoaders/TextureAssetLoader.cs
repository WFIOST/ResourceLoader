using System.Collections;
using System.Collections.Generic;
using BepInEx.Logging;
using UnityEngine;
using ResourceLoader.Common;

namespace ResourceLoader.Core.AssetLoaders
{
    public class TextureAssetLoader : AssetLoader<Texture2D>
    {
        public TextureAssetLoader(ManualLogSource log) : base(log)
        {
            
        }

        public override IEnumerator LoadAsset(AssetManifest manifest)
        {
            yield return null;
        }

        public override void ReplaceAsset(AssetManifest manifest, GameObject spawnedObject)
        {
            throw new System.NotImplementedException();
        }
    }
}