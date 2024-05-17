using UnityEngine;

namespace CatAclysm.Character
{
    [CreateAssetMenu(fileName = "Skills", menuName = "Data/Skill")]
    public class Skill : ScriptableObject
    {
        public string SillName
        { 
            get => skillName; 
            set => skillName = value;
        }
        [SerializeField]
        private string skillName;

        public int BaseSkill
        {
            get => baseSkill; 
            set => baseSkill = value;
        }
        [Range(0, 5)]
        [SerializeField]
        private int baseSkill;

        public int Row
        {
            get => row; 
            set => row = value;
        }
        [Range(0, 5)]
        [SerializeField]
        private int row;
    }
}
