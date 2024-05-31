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

        public CatSkillExpositionBehavior SkillExpositionBehavior { get; set; }

        protected override void CheckButtonsVisibilities()
        {
            base.CheckButtonsVisibilities();
            if (Power != null)
            {
                upArrow.gameObject.SetActive(SkillExpositionBehavior.CanPurchaseSkillRank(currentRank + 1, Power.name));
            }
        }

        public override void PurchaseNextRank() => SkillExpositionBehavior.SetSkillToRank(currentRank + 1, Power.name);
        public override void RestoreToPreviousRank() => SkillExpositionBehavior.SetSkillToRank(currentRank - 1, Power.name);

        protected override void SetTexts()
        {
            base.SetTexts();
            basePoints.text = (Power as Skill).BaseSkill.ToString();
        }
    }
}
