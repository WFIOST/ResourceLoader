using System.Collections;
using System.Collections.Generic;
using BepInEx.Logging;
using UnityEngine;

namespace ResourceLoader.Core
{
    public class TextureAssetLoader : AssetLoader<Texture2D>
    {
        public override IEnumerator LoadAsset(AssetManifest manifest)
        {
            yield return null;
        }

        public override void ReplaceAsset(GameObject spawnedObject)
        {
            throw new System.NotImplementedException();
        }
    }
}