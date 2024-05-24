using CatAclysm.Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CatAclysm.Character.Library
{
    [CreateAssetMenu(fileName = "CharacterAttributeLibrary", menuName = "Data/CharacterAttributeLibrary")]
    public class CharacterAttributesLibrary : ScriptableObject
    {
        #region Properties

        [SerializeField]
        private DiceService dice;

        public IEnumerable<string> NamePrefixes => namePrefixes.AsEnumerable();
        [SerializeField]
        private List<string> namePrefixes = new();
        public IEnumerable<string> NameSuffixes => nameSuffixes.AsEnumerable();
        [SerializeField]
        private List<string> nameSuffixes = new();

        public IEnumerable<Lineage> Lineages => lineages.AsEnumerable();
        [SerializeField]
        private List<Lineage> lineages = new();
        
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

        public IEnumerable<int> SkillRankCosts => skillRankCosts;
        [SerializeField]
        private List<int> skillRankCosts = new(new int[] { 0, 1, 2, 4, 8, 16 });

        public HashSet<Talent> Talents
        {
            get
            { 
                HashSet<Talent> ret = new();
                talents.ForEach(t => ret.Add(Instantiate(t)));
                return ret;
            }
        }
        [SerializeField]
        private List<Talent> talents = new();

        #endregion

        #region Public methods

        public string GenerateName() => $"{namePrefixes[dice.Roll(10) - 1]} {nameSuffixes[dice.Roll(10) - 1]}";

        public string GenerateLineage()
        {
            var prefix = lineages[dice.Roll(6, 2) - 2];
            var suffix = prefix.Suffixes[dice.Roll(6) - 1];
            return suffix.Invert ? $"{suffix.Name} {prefix.name}" : $"{prefix.name} {suffix.Name}";
        }

        #endregion
    }
}
