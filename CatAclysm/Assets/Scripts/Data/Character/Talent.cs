using UnityEngine;

namespace CatAclysm.Character
{
    [CreateAssetMenu(fileName = "Talent", menuName = "Data/Talent")]
    public class Talent : Power
    {
        public string Description
        { 
            get => description;
            set => description = value;
        }
        [SerializeField]
        private string description;

        public override void ComputePoints(Cat cat)
        {
            cat.TalentPoints = (int) Mathf.Pow(2, cat.Vibrisse);
            if (cat.Vibrisse == 5) 
            {
                cat.TalentPoints -= 8;
            }
        }

        protected override int GetPointCapital(Cat cat) => cat.TalentPoints;
        protected override void ConsumePoints(Cat cat, int numberOfPoints) => cat.TalentPoints -= numberOfPoints;
        protected override void RefundPoints(Cat cat, int numberOfPoints) => cat.TalentPoints += numberOfPoints;
        protected override void ResetPoints(Cat cat) => cat.TalentPoints = 0;
    }
}
