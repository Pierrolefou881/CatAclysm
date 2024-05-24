using CatAclysm.Character;
using CatAclysm.Character.Library;
using System.Collections.Generic;
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
                skill.RankCosts = characterAttributesLibrary.SkillRankCosts.ToList();
            }
            theCat.Init(skills, GenerateName(), GenerateLineage(), characterCreationPointsCapital);
        }

        private string GenerateLineage() => characterAttributesLibrary.GenerateLineage();

        private string GenerateName() => characterAttributesLibrary.GenerateName();

        public int ConvertHumanAgeToCat(int humanAge) => Mathf.RoundToInt(humanAge / 5.0f);

        public void GenerateSkillPoints() => theCat.ComputeSkillPoints();
    }
}
