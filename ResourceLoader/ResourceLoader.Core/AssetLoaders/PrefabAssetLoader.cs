using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System;
using ResourceLoader.Common;
using UnityEngine;
using System.Collections;
using FistVR;

namespace ResourceLoader.Core.AssetLoaders
{
    public class PrefabAssetLoader : AssetLoader<Dictionary<FVRObject, GameObject>>
    {
        public override IEnumerator LoadAsset(AssetManifest manifest)
        {
            var additionDict = new Dictionary<FVRObject, GameObject>();
            foreach (AssetFile file in manifest.Files)
            {
                AssetBundleCreateRequest req = AssetBundle.LoadFromFileAsync(file.Path);
                yield return req;

                AssetBundle bundle = req.assetBundle;
                if (bundle == null)
                    throw new FileLoadException($"Could not load bundle at {file.Path}!");
                
                AssetBundleRequest manifestRequest = bundle.LoadAllAssetsAsync<PrefabReplacementManifest>();
                yield return manifestRequest;

                var manifests = (PrefabReplacementManifest[]) manifestRequest.allAssets;
                if (manifests == null)
                    throw new Exception($"Could not get Prefab replacements in bundle {bundle.name}");

                foreach (PrefabReplacementManifest replacementManifest in manifests)
                {
                    AssetBundleRequest replacementLoadReq = bundle.LoadAssetWithSubAssetsAsync<GameObject>(replacementManifest.PrefabReplacement.name);
                    var objID = IM.OD[manifest.Target];
                    yield return replacementLoadReq;
                    GameObject replacementPrefab = (GameObject)replacementLoadReq.asset;
                    if (replacementPrefab == null)
                        throw new Exception($"Could not load replacement prefab in manifest {replacementManifest.name} (Target: {manifest.Target}, Replacement: {replacementManifest.PrefabReplacement.name}))");

                    additionDict.Add(objID, replacementPrefab);    
                }    
            }
            LoadedAssets.Add(manifest, additionDict);
        }

        public override void ReplaceAsset(GameObject spawnedObject)
        {
            throw new NotImplementedException();
        }
    }
}