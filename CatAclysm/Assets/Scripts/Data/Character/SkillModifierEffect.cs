using UnityEngine;

namespace CatAclysm.Character
{
    [CreateAssetMenu(fileName = "SkillModifier", menuName = "Data/Effects/SkillModifierEffect")]
    public class SkillModifierEffect : Effect
    {
        [SerializeField]
        private Skill skillToAffect;

        [SerializeField]
        [Range(-1, 1)]
        private int valueToAffect;

        public override void Apply(Cat cat)
        {
            var skill = cat.Skills.Find(s => s.name == skillToAffect.name);
            skill.BaseSkill += valueToAffect;
        }

        public override void Revert(Cat cat)
        {
            var skill = cat.Skills.Find(s => s.name == skillToAffect.name);
            skill.BaseSkill -= valueToAffect;
        }

        public override string ToString() => $"Compétence {skillToAffect} : {valueToAffect}";

        public override bool CanApply(Cat cat) => cat.SkillPoints + valueToAffect >= 0;
    }
}