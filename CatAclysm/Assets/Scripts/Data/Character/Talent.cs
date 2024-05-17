using UnityEngine;

namespace CatAclysm.Character
{
    [CreateAssetMenu(fileName = "Talent", menuName = "Data/Talent")]
    public class Talent : ScriptableObject
    {
        public string TalentName
        {
            get => talentName; 
            set => talentName = value;
        }
        [SerializeField]
        private string talentName;

        public string Description
        { 
            get => description;
            set => description = value;
        }
        [SerializeField]
        private string description;

        public int Row
        {
            get => row; 
            set => row = value;
        }
        [Range(1, 5)]
        [SerializeField]
        private int row;
    }
}
