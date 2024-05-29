using CatAclysm.Behavior.Events;
using CatAclysm.Character;
using UnityEngine;
using UnityEngine.Events;

namespace CatAclysm.Behavior
{
    public class CatTalentExpositionBehavior : MonoBehaviour
    {
        [SerializeField]
        private Cat cat;

        [SerializeField]
        private UnityEvent<int> talentPointsChanged;

        private void OnEnable()
        {
            cat.TalentPointsChanged += Cat_TalentPointsChanged;
        }

        private void OnDisable()
        {
            cat.TalentPointsChanged -= Cat_TalentPointsChanged;
        }

        public void GenerateTalentPoints() => cat.ComputeTalentPoints();

        public bool CanPurchaseTalentRank(int desiredRank, string talentName)
        { 
            var talent = cat.Talents.Find(t => t.name == talentName);
            return talent != null && talent.CanPurchaseRank(desiredRank, cat);
        }

        public void SetTalentToRank(int desiredRank, string talentName)
        { 
            var talent = cat.Talents.Find(t => t.name == talentName);
            if (talent != null ) 
            {
                if (desiredRank > talent.Rank)
                {
                    talent.PurchaseRank(desiredRank, cat);
                }
                else if (desiredRank < talent.Rank)
                {
                    talent.RefundToRank(desiredRank, cat);
                }
            }
        }

        private void Cat_TalentPointsChanged(object sender, int e)
            => talentPointsChanged.Invoke(e);
    }
}