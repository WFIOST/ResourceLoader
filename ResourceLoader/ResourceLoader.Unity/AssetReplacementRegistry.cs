using System;
using System.Collections.Generic;
using FistVR;
using UnityEngine;

namespace ResourceLoader.Unity
{

    public class AssetReplacementRegistry : ScriptableObject
    {
        [Serializable]
        public class AssetReplacement
        {
            public string       ObjectToReplace;
            public FVRObject    Replacement;
        }
        public List<AssetReplacement> Replacements;
    }
}