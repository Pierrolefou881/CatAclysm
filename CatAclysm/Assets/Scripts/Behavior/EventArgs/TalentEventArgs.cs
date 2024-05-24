using System;

namespace CatAclysm.Behavior.Events
{
    public class TalentEventArgs : EventArgs
    { 
        public string TalentName { get; }
        public int Rank { get; }
        public TalentEventArgs(string talentName, int rank)
        { 
            TalentName = talentName;
            Rank = rank;
        }
    }
}