using CatAclysm.Behavior;
using UnityEngine;

namespace CatAclysm.UI
{
    public class SkillSelector : MonoBehaviour
    {
        [SerializeField]
        private GameObject linePrefab;

        [SerializeField]
        private Transform scrollViewContent;

        [SerializeField]
        private CatSkillExpositionBehavior skillExpositionBehavior;

        private void OnEnable()
        {
            skillExpositionBehavior.GenerateSkillPoints();

            foreach(var skill in skillExpositionBehavior.Skills) 
            {
                if (Instantiate(linePrefab, scrollViewContent).TryGetComponent<SkillLineUI>(out var line))
                {
                    line.Power = skill;
                    line.SkillExpositionBehavior = skillExpositionBehavior;
                }
            }
        }
    }
}
