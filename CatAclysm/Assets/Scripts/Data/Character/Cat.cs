using System.Collections.Generic;
using UnityEngine;

namespace CatAclysm.Character
{
    [CreateAssetMenu(fileName = "Cat", menuName = "Data/Cats")]
    public class Cat : ScriptableObject
    {
        #region Properties

        public string CatName
        {
            get => catName;
            set => catName = value;
        }
        [SerializeField]
        private string catName;

        public string NickName
        {
            get => nickName;
            set => nickName = value;
        }
        [SerializeField]
        private string nickName;

        public int Age
        {
            get => age;
            set => age = value;
        }
        [SerializeField]
        [Range(0, 20)]
        private int age;

        public Sprite Portrait
        {
            get => portrait;
            set => portrait = value;
        }
        [SerializeField]
        private Sprite portrait;

        public Breed Breed
        {
            get => breed;
            set => breed = value;
        }
        [SerializeField]
        private Breed breed;

        public string Lineage
        {
            get => lineage;
            set => lineage = value;
        }
        [SerializeField]
        private string lineage;

        public int Reputation
        {
            get => reputation;
            set => reputation = value;
        }
        [SerializeField]
        private int reputation;

        public string Faction
        {
            get => faction;
            set => faction = value;
        }
        [SerializeField]
        private string faction;

        public List<Quality> Qualities
        {
            get => qualities;
            set => qualities = value; 
        }
        [SerializeField]
        private List<Quality> qualities = new();

        public List<Drawback> Drawbacks
        {
            get => drawbacks;
            set => drawbacks = value;
        }
        [SerializeField]
        private List<Drawback> drawbacks = new();

        public int Griffe
        { 
            get => griffe;
            set => griffe = value;
        }
        [Header("Physical Attributes")]
        [Range(1, 5)]
        [SerializeField]
        private int griffe = 1;

        public int Poil
        {
            get => poil;
            set => poil = value;
        }
        [Range(1, 5)]
        [SerializeField]
        private int poil = 1;

        public int Oeil
        {
            get => oeil;
            set => oeil = value;
        }
        [Range(1, 5)]
        [SerializeField]
        private int oeil = 1;

        public int Queue
        { 
            get => queue;
            set => queue = value;
        }
        [Range(1, 5)]
        [SerializeField]
        private int queue = 1;

        public int Caresse
        {
            get => caresse;
            set => caresse = value;
        }
        [Header("Other Attributes")]
        [Range(1, 5)]
        [SerializeField]
        private int caresse = 1;

        public int Ronronnement
        {
            get => ronronnement; 
            set => ronronnement = value;
        }
        [Range(1, 5)]
        [SerializeField]
        private int ronronnement = 1;

        public int Coussinet
        { 
            get => coussinet; 
            set => coussinet = value;
        }
        [Range(1, 5)]
        [SerializeField]
        private int coussinet = 1;

        public int Vibrisse
        { 
            get => vibrisse; 
            set => vibrisse = value;
        }
        [Range(1, 5)]
        [SerializeField]
        private int vibrisse = 1;

        public int Luck
        { 
            get => luck; 
            set => luck = value;
        }
        [Header("Luck")]
        [Range(1, 3)]
        [SerializeField]
        private int luck = 1;

        public List<Skill> Skills
        {
            get => skills;
            set => skills = value;
        }
        [SerializeField]
        private List<Skill> skills = new();

        public List<Talent> Talents
        { 
            get => talents; 
            set => talents = value; 
        }
        [SerializeField]
        private List<Talent> talents = new();

        #endregion
    }
}
