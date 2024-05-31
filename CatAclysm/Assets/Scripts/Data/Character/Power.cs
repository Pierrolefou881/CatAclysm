using System;
using System.Collections.Generic;
using UnityEngine;

namespace CatAclysm.Character
{
    public abstract class Power : ScriptableObject
    {
        public int Rank
        {
            get => rank;
            protected set
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

        public event EventHandler<int> RankChanged;

        public bool CanPurchaseNextRank(Cat cat)
            => CanPurchaseRank(Rank + 1, cat);

        public bool CanPurchaseRank(int desiredRank, Cat cat)
            => desiredRank >= 0 && desiredRank < RankCosts.Count && Rank < desiredRank && RankCosts[desiredRank] - RankCosts[Rank] <= GetPointCapital(cat);

        protected abstract int GetPointCapital(Cat cat);

        public void PurchaseNextRank(Cat cat) => PurchaseRank(Rank + 1, cat);

        public void PurchaseRank(int desiredRank, Cat cat)
        {
            if (CanPurchaseRank(desiredRank, cat))
            {
                ConsumePoints(cat, RankCosts[desiredRank] - RankCosts[Rank]);
                Rank = desiredRank;
            }
        }

        public bool CanRefundToPreviousRank() => Rank > 0;
        public bool CanRefundToRank(int desiredRank) => desiredRank >= 0 && desiredRank < RankCosts.Count && Rank > desiredRank;

        public void RefundToPreviousRank(Cat cat) => RefundToRank(Rank - 1, cat);

        public void RefundToRank(int desiredRank, Cat cat)
        {
            if (CanRefundToRank(desiredRank))
            {
                RefundPoints(cat, RankCosts[Rank] - RankCosts[desiredRank]);
                Rank = desiredRank;
            }
        }

        public void ResetRank(Cat cat)
        {
            ResetPoints(cat);
            Rank = 0;
        }

        protected abstract void ConsumePoints(Cat cat, int numberOfPoints);
        protected abstract void RefundPoints(Cat cat, int numberOfPoints);
        protected abstract void ResetPoints(Cat cat);
    }
}