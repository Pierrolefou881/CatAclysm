using System;
using UnityEngine;

namespace CatAclysm.Character
{
    [CreateAssetMenu(fileName = "Skills", menuName = "Data/Skill")]
    public class Skill : ScriptableObject
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

        public int Row
        {
            get => row;
            set 
            {
                if (row != value) 
                {
                    row = value;
                    RowChanged?.Invoke(this, row);
                }
            }
        }
        [Range(0, 5)]
        [SerializeField]
        private int row;

        [SerializeField]
        private Characteristics primaryCharacteristics;

        [SerializeField]
        private Characteristics secondaryCharacteristics;

        public event EventHandler<int> BaseSkillChanged;
        public event EventHandler<int> RowChanged;

        public void ComputeSkillPoints(Cat cat) 
        {
            var skillPoints = cat.GetBaseStatByEnum(primaryCharacteristics);
            BaseSkill = secondaryCharacteristics == Characteristics.None ? skillPoints : (skillPoints + cat.GetBaseStatByEnum(secondaryCharacteristics)) / 2;
        }
    }
}
