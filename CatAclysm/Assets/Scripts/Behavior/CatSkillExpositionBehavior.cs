using CatAclysm.Behavior.Events;
using CatAclysm.Character;
using UnityEngine;
using UnityEngine.Events;

namespace CatAclysm.Behavior
{
    public class CatSkillExpositionBehavior : MonoBehaviour
    {
        [SerializeField]
        private Cat cat;

        [SerializeField]
        private UnityEvent<SkillEventArgs> skillChanged;

        private void OnEnable()
        {
            foreach (var s in cat.Skills) 
            {
                s.BaseSkillChanged += Skill_SkillChanged;
                s.RankChanged += Skill_SkillChanged;
            }
        }

        private void OnDisable() 
        {
            foreach (var s in cat.Skills)
            {
                s.BaseSkillChanged -= Skill_SkillChanged;
                s.RankChanged -= Skill_SkillChanged;
            }
        }

        public void SetSkillValue(string skillName, int value, bool changeRow = true)
        { 
            var skill = cat.Skills.Find(s => s.name == skillName);
            if (skill != null) 
            {
                if (changeRow)
                {
                    skill.Rank = value;
                }
                else
                {
                    skill.BaseSkill = value;
                }
            }
        }

        private void Skill_SkillChanged(object sender, int e)
        { 
            if (sender is Skill skill) 
            {
                skillChanged.Invoke(new SkillEventArgs(skill.name, skill.BaseSkill, skill.Rank));
            }
        }
    }
}