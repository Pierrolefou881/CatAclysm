using CatAclysm.Behavior;
using CatAclysm.Character;
using CatAclysm.Services;
using TMPro;
using UnityEngine;

namespace CatAclysm.UI
{
    public class QualitiesDrawbacksSelector : MonoBehaviour
    {
        [SerializeField] private CatQualitiesDefaultsExpositionBehavior qualitiesDefaultsExpositionBehavior;

        [SerializeField] private CharacterCreationService creationService;
        [SerializeField] private TMP_Dropdown qualitiesDropDowns;
        [SerializeField] private TMP_Dropdown defaultsDropDowns;
        [SerializeField] private TextMeshProUGUI effectTMP;

        void Start()
        {
            qualitiesDropDowns.options.Clear();
            defaultsDropDowns.options.Clear();
            foreach (Quality quality in qualitiesDefaultsExpositionBehavior.GetQualities())
            {
                qualitiesDropDowns.options.Add(new TMP_Dropdown.OptionData(quality.name));
            }
            foreach (Drawback drawback in qualitiesDefaultsExpositionBehavior.GetDrawbacks())
            {
                defaultsDropDowns.options.Add(new TMP_Dropdown.OptionData(drawback.name));
            }
            /*
            LoadBreeds();
            effectTMP.text = creationService.Breeds.ElementAt(0).ToString();
            breedsDropDown.onValueChanged.AddListener((i) =>
            {
                effectTMP.text = creationService.Breeds.ElementAt(i).ToString();
            });
            */
        }

        private void LoadQualitiesAndDrawbacks()
        {

        }

        /*
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
        */
    }
}
