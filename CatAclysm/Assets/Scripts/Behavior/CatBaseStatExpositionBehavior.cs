using CatAclysm.Character;
using CatAclysm.Services;
using UnityEngine;
using UnityEngine.Events;

namespace CatAclysm.Behavior
{
    public class CatBaseStatExpositionBehavior : MonoBehaviour
    {
        [SerializeField]
        private Cat cat;

        [SerializeField]
        private CharacterCreationService characterCreationService;

        [SerializeField]
        private UnityEvent<string> catNameChanged;

        [SerializeField]
        private UnityEvent<string> griffeChanged;

        [SerializeField]
        private UnityEvent<string> poilChanged;

        [SerializeField]
        private UnityEvent<string> queueChanged;

        [SerializeField]
        private UnityEvent<string> luckChanged;

        [SerializeField]
        private UnityEvent<string> caresseChanged;

        [SerializeField]
        private UnityEvent<string> oeilChanged;

        [SerializeField]
        private UnityEvent<string> ronronnementChanged;

        [SerializeField]
        private UnityEvent<string> vibrisseChanged;

        [SerializeField]
        private UnityEvent<string> coussinetChanged;

        [SerializeField]
        private UnityEvent<string> remainingPointCapitalChanged;

        private void OnEnable()
        {
            cat.NameChanged += Cat_NameChanged;
            cat.GriffeChanged += Cat_GriffeChanged;
            cat.PoilChanged += Cat_PoilChanged;
            cat.QueueChanged += Cat_QueueChanged;
            cat.LuckChanged += Cat_LuckChanged;
            cat.CaresseChanged += Cat_CaresseChanged;
            cat.OeilChanged += Cat_OeilChanged;
            cat.RonronnementChanged += Cat_RonronnementChanged;
            cat.VibrisseChanged += Cat_VibrisseChanged;
            cat.CoussinetChanged += Cat_CoussinetChanged;
            cat.RemainingPointCapitalChanged += Cat_RemainingPointCapitalChanged;
        }



        private void OnDisable()
        {
            cat.NameChanged -= Cat_NameChanged;
            cat.GriffeChanged -= Cat_GriffeChanged;
            cat.PoilChanged -= Cat_PoilChanged;
            cat.QueueChanged -= Cat_QueueChanged;
            cat.LuckChanged -= Cat_LuckChanged;
            cat.CaresseChanged -= Cat_CaresseChanged;
            cat.OeilChanged -= Cat_OeilChanged;
            cat.RonronnementChanged -= Cat_RonronnementChanged;
            cat.VibrisseChanged -= Cat_VibrisseChanged;
            cat.CoussinetChanged -= Cat_CoussinetChanged;
            cat.RemainingPointCapitalChanged -= Cat_RemainingPointCapitalChanged;
        }

        #region Cat Setters

        public void ResetCat() => characterCreationService.InitCat();
        public void SetGriffe(int value) => cat.Griffe = value;
        public void SetPoil(int value) => cat.Poil = value;
        public void SetQueue(int value) => cat.Queue = value;
        public void SetOeil(int value) => cat.Oeil = value;
        public void SetLuck(int value) => cat.Luck = value;
        public void SetCoussinet(int value) => cat.Coussinet = value;
        public void SetVibrisse(int value) => cat.Vibrisse = value;
        public void SetRonronnement(int value) => cat.Ronronnement = value;
        public void SetCaresse(int value) => cat.Caresse = value;

        #endregion


        #region Callbacks

        private void Cat_NameChanged(object sender, string e)
            => catNameChanged.Invoke(e);

        private void Cat_GriffeChanged(object sender, int e)
            => griffeChanged.Invoke(e.ToString());

        private void Cat_PoilChanged(object sender, int e)
            => poilChanged?.Invoke(e.ToString());

        private void Cat_QueueChanged(object sender, int e)
            => queueChanged?.Invoke(e.ToString());

        private void Cat_LuckChanged(object sender, int e)
            => luckChanged?.Invoke(e.ToString());

        private void Cat_CaresseChanged(object sender, int e)
            => caresseChanged?.Invoke(e.ToString());

        private void Cat_OeilChanged(object sender, int e)
            => oeilChanged?.Invoke(e.ToString());

        private void Cat_RonronnementChanged(object sender, int e)
            => ronronnementChanged?.Invoke(e.ToString());
        private void Cat_VibrisseChanged(object sender, int e)
            => vibrisseChanged?.Invoke(e.ToString());

        private void Cat_CoussinetChanged(object sender, int e)
            => coussinetChanged?.Invoke(e.ToString());

        private void Cat_RemainingPointCapitalChanged(object sender, int e)
            => remainingPointCapitalChanged?.Invoke(e.ToString());

        #endregion
    }
}
