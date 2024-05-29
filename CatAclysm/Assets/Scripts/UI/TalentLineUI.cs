using CatAclysm.Behavior;
using CatAclysm.Character;
using UnityEngine;

namespace CatAclysm.UI
{
    public class TalentLineUI : PowerLineUI
    {
        [SerializeField]
        private CatTalentExpositionBehavior talentExpositionBehavior;

        public override void PurchaseNextRank() => talentExpositionBehavior.SetTalentToRank(currentRank + 1, Power.name);
        public override void RestoreToPreviousRank() => talentExpositionBehavior.SetTalentToRank(currentRank - 1, Power.name);
    }
}