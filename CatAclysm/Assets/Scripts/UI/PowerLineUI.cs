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

        protected virtual void CheckButtonsVisibilities()
        {
            downArrow.gameObject.SetActive(currentRank != 0);
        }

        public abstract void PurchaseNextRank();
        public abstract void RestoreToPreviousRank();
    }
}