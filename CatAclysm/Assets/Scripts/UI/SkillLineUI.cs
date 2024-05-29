using CatAclysm.Behavior;
using CatAclysm.Character;
using TMPro;
using UnityEngine;

namespace CatAclysm.UI
{
    public class SkillLineUI : PowerLineUI
    {
        [SerializeField]
        private TextMeshProUGUI basePoints;

        [SerializeField]
        private CatSkillExpositionBehavior skillExpositionBehavior;

        protected override void OnEnable()
        {
            base.OnEnable();
            basePoints.text = (Power as Skill).BaseSkill.ToString();
        }

        protected override void CheckButtonsVisibilities()
        {
            base.CheckButtonsVisibilities();
            upArrow.gameObject.SetActive(skillExpositionBehavior.CanPurchaseSkillRank(currentRank + 1, Power.name));
        }

        public override void PurchaseNextRank() => skillExpositionBehavior.SetSkillToRank(currentRank + 1, Power.name);
        public override void RestoreToPreviousRank() => skillExpositionBehavior.SetSkillToRank(currentRank - 1, Power.name);
    }
}
