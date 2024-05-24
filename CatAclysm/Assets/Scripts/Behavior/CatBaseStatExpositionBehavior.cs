using CatAclysm.Character;
using UnityEngine;
using UnityEngine.Events;

namespace CatAclysm.Behavior
{
    public class CatBaseStatExpositionBehavior : MonoBehaviour
    {
        [SerializeField]
        private Cat cat;

        [SerializeField]
        private UnityEvent<string> catNameChanged;

        [SerializeField]
        private UnityEvent<int> griffeChanged;

        [SerializeField]
        private UnityEvent<int> poilChanged;

        [SerializeField]
        private UnityEvent<int> queueChanged;

        [SerializeField]
        private UnityEvent<int> luckChanged;

        [SerializeField]
        private UnityEvent<int> caresseChanged;

        [SerializeField]
        private UnityEvent<int> oeilChanged;

        [SerializeField]
        private UnityEvent<int> ronronnementChanged;

        [SerializeField]
        private UnityEvent<int> vibrisseChanged;

        [SerializeField]
        private UnityEvent<int> coussinetChanged;

        [SerializeField]
        private UnityEvent<int> remainingPointCapitalChanged;

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
            => griffeChanged.Invoke(e);

        private void Cat_PoilChanged(object sender, int e)
            => poilChanged?.Invoke(e);

        private void Cat_QueueChanged(object sender, int e)
            => queueChanged?.Invoke(e);

        private void Cat_LuckChanged(object sender, int e)
            => luckChanged?.Invoke(e);

        private void Cat_CaresseChanged(object sender, int e)
            => caresseChanged?.Invoke(e);

        private void Cat_OeilChanged(object sender, int e)
            => oeilChanged?.Invoke(e);

        private void Cat_RonronnementChanged(object sender, int e)
            => ronronnementChanged?.Invoke(e);
        private void Cat_VibrisseChanged(object sender, int e)
            => vibrisseChanged?.Invoke(e);

        private void Cat_CoussinetChanged(object sender, int e)
            => coussinetChanged?.Invoke(e);

        private void Cat_RemainingPointCapitalChanged(object sender, int e)
            => remainingPointCapitalChanged?.Invoke(e);

        #endregion
    }
}
