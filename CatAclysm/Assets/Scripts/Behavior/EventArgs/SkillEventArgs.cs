using System;

namespace CatAclysm.Behavior.Events
{
    public class SkillEventArgs : EventArgs
    { 
        public string SkillName { get; }
        public int SkillBase { get; }
        public int SkillRow { get; }
        public SkillEventArgs(string skillName, int skillBase, int skillRow)
        {
            SkillName = skillName;
            SkillBase = skillBase;
            SkillRow = skillRow;
        }
    }
}