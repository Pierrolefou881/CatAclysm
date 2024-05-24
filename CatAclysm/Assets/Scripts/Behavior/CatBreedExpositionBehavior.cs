using CatAclysm.Character;
using UnityEngine;
using UnityEngine.Events;

namespace CatAclysm.Behavior
{
    public class CatBreedExpositionBehavior : MonoBehaviour
    {
        [SerializeField]
        private Cat cat;

        [SerializeField]
        private UnityEvent<Breed> breedChanged;

        private void OnEnable()
        {
            cat.BreedChanged += Cat_BreedChanged;
        }

        private void OnDisable()
        {
            cat.BreedChanged -= Cat_BreedChanged;
        }

        public void SetCatBreed(Breed breed) => cat.Breed = breed;

        private void Cat_BreedChanged(object sender, Breed e)
            => breedChanged?.Invoke(e);
    }
}