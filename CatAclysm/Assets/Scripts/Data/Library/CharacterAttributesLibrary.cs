using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CatAclysm.Character.Library
{
    [CreateAssetMenu(fileName = "CharacterAttributeLibrary", menuName = "Data/CharacterAttributeLibrary")]
    public class CharacterAttributesLibrary : ScriptableObject
    {
        public IEnumerable<string> NamePrefixes => namePrefixes.AsEnumerable();
        [SerializeField]
        private List<string> namePrefixes = new();
        public IEnumerable<string> NameSuffixes => nameSuffixes.AsEnumerable();
        [SerializeField]
        private List<string> nameSuffixes = new();

        public IEnumerable<string> LineagePrefixes => lineagePrefixes.AsEnumerable();
        [SerializeField]
        private List<string> lineagePrefixes = new();
        public IEnumerable<string> LineageSuffixes => lineageSuffixes.AsEnumerable();
        [SerializeField]
        private List<string> lineageSuffixes = new();

        public IEnumerable<string> Factions => factions.AsEnumerable();
        [SerializeField]
        private List<string> factions = new();

        public IEnumerable<Quality> Qualities => qualities.AsEnumerable();
        [SerializeField]
        private List<Quality> qualities = new();

        public IEnumerable<Drawback> Drawbacks => drawbacks.AsEnumerable();
        [SerializeField]
        private List<Drawback> drawbacks = new();

        public HashSet<Skill> Skills 
        {
            get
            {
                HashSet<Skill> ret = new();
                skills.ForEach(s => ret.Add(Instantiate(s)));
                return ret;
            }
        }
        [SerializeField]
        private List<Skill> skills = new();

        public IEnumerable<Talent> Talents => talents.AsEnumerable();
        [SerializeField]
        private List<Talent> talents = new();
    }
}
