using CatAclysm.Behavior;
using UnityEngine;

namespace CatAclysm.UI
{
    public class TalentSelector : MonoBehaviour
    {
        [SerializeField]
        private GameObject linePrefab;

        [SerializeField]
        private Transform scrollViewContent;

        [SerializeField]
        private CatTalentExpositionBehavior talentExpositionBehavior;

        private void OnEnable()
        {
            talentExpositionBehavior.GenerateTalentPoints();

            foreach (var talent in talentExpositionBehavior.Talents)
            {
                if (Instantiate(linePrefab, scrollViewContent).TryGetComponent<TalentLineUI>(out var line))
                {
                    line.Power = talent;
                    line.TalentExpositionBehavior = talentExpositionBehavior;
                }
            }
        }
    }
}