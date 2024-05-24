using CatAclysm.Character;
using CatAclysm.Character.Library;
using System.Linq;
using UnityEngine;

namespace CatAclysm.Services
{
    [CreateAssetMenu(fileName = "CharacterCreationService", menuName ="Services/CharacterCreationService")]
    public class CharacterCreationService : ScriptableObject
    {
        [SerializeField]
        private CharacterAttributesLibrary characterAttributesLibrary;

        [SerializeField]
        private Cat theCat;

        [SerializeField]
        [Range(20, 28)]
        private int characterCreationPointsCapital;

        private void OnEnable()
        {
            InitCat(); 
        }

        [ContextMenu("Create new cat")]
        public void InitCat()
        { 
            var skills = characterAttributesLibrary.Skills;
            foreach (var skill in skills)
            {
                skill.RankCosts = characterAttributesLibrary.RankCosts.ToList();
            }
            
            var talents = characterAttributesLibrary.Talents;
            foreach (var talent in talents)
            {
                talent.RankCosts = characterAttributesLibrary.RankCosts.ToList();
            }

            theCat.Init(skills, talents, GenerateName(), GenerateLineage(), characterCreationPointsCapital);
        }

        private string GenerateLineage() => characterAttributesLibrary.GenerateLineage();

        private string GenerateName() => characterAttributesLibrary.GenerateName();

        public int ConvertHumanAgeToCat(int humanAge) => Mathf.RoundToInt(humanAge / 5.0f);
    }
}
