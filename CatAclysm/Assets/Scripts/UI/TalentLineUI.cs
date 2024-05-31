using CatAclysm.Behavior;
using CatAclysm.Character;
using UnityEngine;

namespace CatAclysm.UI
{
    public class TalentLineUI : PowerLineUI
    {
        public CatTalentExpositionBehavior TalentExpositionBehavior { get; set; }

        public override void PurchaseNextRank() => TalentExpositionBehavior.SetTalentToRank(currentRank + 1, Power.name);
        public override void RestoreToPreviousRank() => TalentExpositionBehavior.SetTalentToRank(currentRank - 1, Power.name);
    }
}