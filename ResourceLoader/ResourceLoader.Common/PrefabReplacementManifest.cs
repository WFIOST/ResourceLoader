using UnityEngine;

namespace ResourceLoader.Common
{
    [CreateAssetMenu(menuName = "ResourceLoader/Prefab Replacement", fileName = "New Prefab Replacment")]
    public class PrefabReplacementManifest : ScriptableObject
    {
        public GameObject   PrefabReplacement;
    }
}