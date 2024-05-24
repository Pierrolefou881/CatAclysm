using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

namespace CatAclysm.Character
{
    [CreateAssetMenu(fileName = "Skills", menuName = "Data/Skill")]
    public class Skill : ScriptableObject
    {
        public int BaseSkill
        {
            get => baseSkill;
            set
            { 
                if (baseSkill != value) 
                {
                    baseSkill = value;
                    BaseSkillChanged?.Invoke(this, baseSkill);
                }
            }
        } 
        [Range(0, 5)]
        [SerializeField]
        private int baseSkill;

        public int Rank
        {
            get => rank;
            set 
            {
                if (rank != value) 
                {
                    rank = value;
                    RankChanged?.Invoke(this, rank);
                }
            }
        }
        [Range(0, 5)]
        [SerializeField]
        private int rank;

        public List<int> RankCosts
        {
            get => rankCosts;
            set => rankCosts = value;
        }
        [SerializeField]
        private List<int> rankCosts = new();

        [SerializeField]
        private Characteristics primaryCharacteristics;

        [SerializeField]
        private Characteristics secondaryCharacteristics;

        public event EventHandler<int> BaseSkillChanged;
        public event EventHandler<int> RankChanged;

        public void ComputeSkillPoints(Cat cat) 
        {
            var skillPoints = cat.GetBaseStatByEnum(primaryCharacteristics);
            BaseSkill = secondaryCharacteristics == Characteristics.None ? skillPoints : (skillPoints + cat.GetBaseStatByEnum(secondaryCharacteristics)) / 2;
        }

        public bool CanPurchaseNextRank(Cat cat)
            => CanPurchaseRank(Rank + 1, cat);

        public bool CanPurchaseRank(int desiredRank, Cat cat)
            => desiredRank >= 0 && desiredRank < rankCosts.Count && Rank < desiredRank && RankCosts[desiredRank] - RankCosts[Rank] >= cat.SkillPoints;

        public void PurchaseNextRank(Cat cat) => PurchaseRank(Rank + 1, cat);

        public void PurchaseRank(int desiredRank, Cat cat) 
        {
            if (CanPurchaseRank(desiredRank, cat))
            {
                cat.SkillPoints -= RankCosts[desiredRank] - RankCosts[Rank];
                Rank = desiredRank;
            }
        }

        public bool CanRefundToPreviousRank() => Rank > 0;
        public bool CanRefundToRank(int desiredRank) => desiredRank >= 0 && desiredRank < rankCosts.Count && Rank > desiredRank;

        public void RefundToPreviousRank(Cat cat) => RefundToRank(Rank - 1, cat);

        public void RefundToRank(int desiredRank, Cat cat)
        {
            if (CanRefundToRank(desiredRank))
            {
                cat.SkillPoints += RankCosts[Rank] - RankCosts[desiredRank];
                Rank = desiredRank;
            }
        }

        public void ResetRank(Cat cat)
        {
            cat.SkillPoints += RankCosts[Rank];
            Rank = 0;
        }
    }
}
