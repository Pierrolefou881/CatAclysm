using CatAclysm.Behavior.Events;
using CatAclysm.Character;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace CatAclysm.Behavior
{
    public class CatSkillExpositionBehavior : MonoBehaviour
    {
        [SerializeField]
        private Cat cat;

        [SerializeField]
        private UnityEvent<string> skillPointCapitalChanged;

        private void OnEnable()
        {
            cat.SkillPointsChanged += Cat_SkillPointsChanged;
        }

        private void OnDisable()
        {
            cat.SkillPointsChanged -= Cat_SkillPointsChanged;
        }

        public void GenerateSkillPoints() => cat.ComputeSkillPoints();

        public bool CanPurchaseSkillRank(int desiredRank, string skillName)
        {
            var skill = cat.Skills.Find(s => s.name == skillName);
            return skill != null && skill.CanPurchaseRank(desiredRank, cat);
        }

        public void SetSkillToRank(int desiredRank, string skillName)
        {
            var skill = cat.Skills.Find(s => s.name == skillName);
            if (skill != null)
            {
                if (desiredRank > skill.Rank)
                {
                    skill.PurchaseRank(desiredRank, cat);
                }
                else if (desiredRank < skill.Rank)
                {
                    skill.RefundToRank(desiredRank, cat);
                }
            }
        }

        private void Cat_SkillPointsChanged(object sender, int e)
            => skillPointCapitalChanged.Invoke(e.ToString());
    }
}