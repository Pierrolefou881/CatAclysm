using CatAclysm.Character;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CatAclysm.UI
{
    public abstract class PowerLineUI : MonoBehaviour
    {
        [SerializeField]
        protected TextMeshProUGUI powerName;

        [SerializeField]
        protected TextMeshProUGUI rank;
        protected int currentRank;

        [SerializeField]
        protected Button downArrow;

        [SerializeField]
        protected Button upArrow;

        public Power Power { get; set; }

        protected virtual void OnEnable()
        {
            powerName.text = Power.name;
            rank.text = Power.Rank.ToString();
            currentRank = Power.Rank;
            Power.RankChanged += Power_RankChanged;
            CheckButtonsVisibilities();
        }

        private void OnDisable()
        {
            Power.RankChanged -= Power_RankChanged;
        }

        private void Power_RankChanged(object sender, int e)
        {
            rank.text = e.ToString();
            currentRank = e;
            CheckButtonsVisibilities();
        }

        protected virtual void CheckButtonsVisibilities()
        {
            downArrow.gameObject.SetActive(currentRank != 0);
        }

        public abstract void PurchaseNextRank();
        public abstract void RestoreToPreviousRank();
    }
}