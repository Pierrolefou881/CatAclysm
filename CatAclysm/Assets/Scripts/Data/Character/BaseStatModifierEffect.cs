using UnityEngine;

namespace CatAclysm.Character
{
    [CreateAssetMenu(fileName = "BaseStatModifierEffect", menuName = "Data/Effects/BaseStatModifierEffect")]
    public class BaseStatModifierEffect : Effect
    {
        [SerializeField]
        private Characteristics baseStatsToAffect;

        [SerializeField]
        [Range(-2, 2)]
        private int valueToApply;

        public override void Apply(Cat cat)
        {
            switch (baseStatsToAffect) 
            {
                case Characteristics.Griffe:
                    cat.Griffe += valueToApply;
                    break;
                case Characteristics.Poil:
                    cat.Poil += valueToApply;
                    break;
                case Characteristics.Oeil:
                    cat.Oeil += valueToApply;
                    break;
                case Characteristics.Queue:
                    cat.Queue += valueToApply;
                    break;
                case Characteristics.Caresse:
                    cat.Caresse += valueToApply;
                    break;
                case Characteristics.Ronronnement:
                    cat.Ronronnement += valueToApply;
                    break;
                case Characteristics.Coussinet:
                    cat.Coussinet += valueToApply;
                    break;
                case Characteristics.Vibirisse:
                    cat.Vibrisse += valueToApply;
                    break;
                default: 
                    break;
            }
        }

        public override void Revert(Cat cat)
        {
            switch (baseStatsToAffect)
            {
                case Characteristics.Griffe:
                    cat.Griffe -= valueToApply;
                    break;
                case Characteristics.Poil:
                    cat.Poil -= valueToApply;
                    break;
                case Characteristics.Oeil:
                    cat.Oeil -= valueToApply;
                    break;
                case Characteristics.Queue:
                    cat.Queue -= valueToApply;
                    break;
                case Characteristics.Caresse:
                    cat.Caresse -= valueToApply;
                    break;
                case Characteristics.Ronronnement:
                    cat.Ronronnement -= valueToApply;
                    break;
                case Characteristics.Coussinet:
                    cat.Coussinet -= valueToApply;
                    break;
                case Characteristics.Vibirisse:
                    cat.Vibrisse -= valueToApply;
                    break;
                default:
                    break;
            }
        }

        public override bool CanApply(Cat cat) => cat.GetBaseStatByEnum(baseStatsToAffect) + valueToApply > 0;
        public override string ToString() => $"Caractéristique {baseStatsToAffect} : {valueToApply}";
    }
}