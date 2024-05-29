using System;
using UnityEngine;

namespace CatAclysm.Character
{
    [CreateAssetMenu(fileName = "Skills", menuName = "Data/Skill")]
    public class Skill : Power
    {
        public int BaseSkill
        {
            get => baseSkill;
            set
            { 
                if (baseSkill != value) 
                {
                    baseSkill = value;
                    BaseSkillChanged?.Invoke(this, baseSkill);
                }
            }
        } 
        [Range(0, 5)]
        [SerializeField]
        private int baseSkill;

        [SerializeField]
        private Characteristics primaryCharacteristics;

        [SerializeField]
        private Characteristics secondaryCharacteristics;

        public event EventHandler<int> BaseSkillChanged;

        public void ComputeBasePoints(Cat cat) 
        {
            var skillPoints = cat.GetBaseStatByEnum(primaryCharacteristics);
            BaseSkill += secondaryCharacteristics == Characteristics.None ? skillPoints : (int)((skillPoints + cat.GetBaseStatByEnum(secondaryCharacteristics)) / 2.0 + 1);
        }

        protected override int GetPointCapital(Cat cat) => cat.SkillPoints;
        protected override void ConsumePoints(Cat cat, int numberOfPoints) => cat.SkillPoints -= numberOfPoints;
        protected override void RefundPoints(Cat cat, int numberOfPoints) => cat.SkillPoints += numberOfPoints;
        protected override void ResetPoints(Cat cat) => cat.SkillPoints = 0;
    }
}
