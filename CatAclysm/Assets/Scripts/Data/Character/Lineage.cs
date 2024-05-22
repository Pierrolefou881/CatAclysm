using System;
using System.Collections.Generic;
using UnityEngine;

namespace CatAclysm.Character
{
    [CreateAssetMenu]
    public class Lineage : ScriptableObject
    {
        public List<LineageSuffix> Suffixes
        { 
            get => suffixes; 
            set => suffixes = value;
        }
        [SerializeField]
        private List<LineageSuffix> suffixes;
        
        [Serializable]
        public class LineageSuffix
        {
            public string Name;
            public bool Invert;
        }
    }
}
