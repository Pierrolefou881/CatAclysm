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
                s.BaseSkillChanged += Skill_BaseSkillChanged;
                s.RowChanged += Skill_BaseSkillChanged;
            }
        }

        private void OnDisable() 
        {
            foreach (var s in cat.Skills)
            {
                s.BaseSkillChanged -= Skill_BaseSkillChanged;
                s.RowChanged -= Skill_BaseSkillChanged;
            }
        }

        public void SetSkillValue(string skillName, int value, bool changeRow = false)
        { 
            var skill = cat.Skills.Find(s => s.name == skillName);
            if (skill != null) 
            {
                if (changeRow)
                {
                    skill.Row = value;
                }
                else
                {
                    skill.BaseSkill = value;
                }
            }
        }

        private void Skill_BaseSkillChanged(object sender, int e)
        { 
            if (sender is Skill skill) 
            {
                skillChanged.Invoke(new SkillEventArgs(skill.name, skill.BaseSkill, skill.Row));
            }
        }
    }
}