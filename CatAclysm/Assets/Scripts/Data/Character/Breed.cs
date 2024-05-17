using UnityEngine;

namespace CatAclysm.Character
{
    [CreateAssetMenu(fileName = "Breed", menuName = "Data/Breeds")]
    public class Breed : ScriptableObject
    {
        public string BreedName
        {
            get => breedName; 
            set => breedName = value;
        }
        [SerializeField]
        private string breedName;
    }
}
