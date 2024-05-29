using CatAclysm.Behavior;
using CatAclysm.Character;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CatAclysm.UI
{
    public class SkillLineUI : PowerLineUI
    {
        [SerializeField]
        private TextMeshProUGUI basePoints;

        [SerializeField]
        private CatSkillExpositionBehavior skillExpositionBehavior;

        public Skill Skill { get; set; }

        private void OnEnable()
        {
            powerName.text = Skill.name;
            basePoints.text = Skill.BaseSkill.ToString();
            rank.text = Skill.Rank.ToString();
            currentRank = Skill.Rank;
            Skill.RankChanged += Skill_RankChanged;
            CheckButtonsVisibilities();
        }

        private void OnDisable()
        {
            Skill.RankChanged -= Skill_RankChanged;
        }

        private void Skill_RankChanged(object sender, int e)
        {
            rank.text = e.ToString();
            currentRank = e;
            CheckButtonsVisibilities();
        }

        protected override void CheckButtonsVisibilities()
        {
            base.CheckButtonsVisibilities();
            upArrow.gameObject.SetActive(skillExpositionBehavior.CanPurchaseSkillRank(currentRank + 1, Skill.name));
        }

        public override void PurchaseNextRank() => skillExpositionBehavior.SetSkillToRank(currentRank + 1, Skill.name);
        public override void RestoreToPreviousRank() => skillExpositionBehavior.SetSkillToRank(currentRank - 1, Skill.name);
    }
}
