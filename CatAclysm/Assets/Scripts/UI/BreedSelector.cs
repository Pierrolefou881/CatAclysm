using CatAclysm.Behavior;
using CatAclysm.Character;
using CatAclysm.Services;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace CatAclysm.UI
{
    public class BreedSelector : MonoBehaviour
    {
        [SerializeField] private CatBreedExpositionBehavior catBreed;

        [SerializeField] private CharacterCreationService creationService;
        [SerializeField] private TMP_Dropdown breedsDropDown;
        [SerializeField] private TextMeshProUGUI effectTMP;

        void Start()
        {
            LoadBreeds();
            effectTMP.text = creationService.Breeds.ElementAt(0).ToString();
            breedsDropDown.onValueChanged.AddListener((i) =>
            {
                effectTMP.text = creationService.Breeds.ElementAt(i).ToString();
            });
        }

        private void LoadBreeds()
        {
            breedsDropDown.ClearOptions();
            List<TMP_Dropdown.OptionData> options = new();
            foreach (Breed breed in creationService.Breeds)
            {
                options.Add(new(breed.name));
            }
            breedsDropDown.AddOptions(options);
        }
    }
}
