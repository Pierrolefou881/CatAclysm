using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace CatAclysm.Character
{
    [CreateAssetMenu()]
    public class Cat : ScriptableObject
    {
        #region Properties

        public int Griffe 
        {
            get => griffe;
            set => griffe = value;
        }
        [SerializeField]
        private int griffe;

        public int Poil
        {
            get => poil;
            set => poil = value;
        }
        [SerializeField]
        private int poil;

        public int Oeil 
        {
            get => oeil;
            set => oeil = value;
        }
        [SerializeField]
        private int oeil;

        public int Queue 
        {
            get => queue;
            set => queue = value;
        }
        [SerializeField]
        private int queue;

        public int Ronronnement 
        {
            get => ronronnement; 
            set => ronronnement = value;
        }
        [SerializeField]
        private int ronronnement;

        public int Caresse 
        {
            get => caresse; 
            set => caresse = value;
        }
        [SerializeField]
        private int caresse;

        public int Vibrisse 
        {
            get => vibrisse;
            set => vibrisse = value; 
        }
        [SerializeField]
        private int vibrisse;

        public int Coussinet 
        {
            get => coussinet; 
            set => coussinet = value;
        }
        [SerializeField]
        private int coussinet;


        #endregion
    }
}
