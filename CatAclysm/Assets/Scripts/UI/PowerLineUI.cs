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

        public Power Power 
        {
            get => power;
            set
            {
                if (power != null)
                {
                    power.RankChanged -= Power_RankChanged;
                }
                power = value;
                power.RankChanged += Power_RankChanged;
                SetTexts();
            }
        }
        private Power power;

        protected void OnEnable()
        {
            CheckButtonsVisibilities();
        }

        private void OnDisable()
        {
            if (Power != null)
            {
                Power.RankChanged -= Power_RankChanged;
            }
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

        protected virtual void SetTexts() 
        {
            powerName.text = power.name;
            rank.text = power.Rank.ToString();
            currentRank = power.Rank;
        }

        public abstract void PurchaseNextRank();
        public abstract void RestoreToPreviousRank();
    }
}