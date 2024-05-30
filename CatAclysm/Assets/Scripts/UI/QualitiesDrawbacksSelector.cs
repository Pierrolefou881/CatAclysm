using CatAclysm.Behavior;
using CatAclysm.Character;
using CatAclysm.Services;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CatAclysm.UI
{
    public class QualitiesDrawbacksSelector : MonoBehaviour
    {
        [Header("Services & Behavior")]
        [SerializeField] private CatQualitiesDefaultsExpositionBehavior qualitiesDefaultsExpositionBehavior;
        [SerializeField] private CharacterCreationService creationService;
        [Header("DropDowns")]
        [SerializeField] private TMP_Dropdown qualitiesDropDowns;
        [SerializeField] private TMP_Dropdown drawbacksDropDowns;
        [Header("ScrollViews")]
        [SerializeField] private Transform qualitiesContent;
        [SerializeField] private Transform drawbacksContent;
        [Header("AddButtons")]
        [SerializeField] private Button qualityAddButton;
        [SerializeField] private Button drawbackAddButton;
        [SerializeField] private readonly int maxNbTraits = 3;
        [Header("Prefabs")]
        [SerializeField] private GameObject itemPrefab;

        [Header("Not Removables Qualities & Drawbacks")]
        [SerializeField] private List<Quality> qualitiesNotRemovables;
        [SerializeField] private List<Drawback> drawbacksNotRemovables;

        private int nbTraits;

        void Start()
        {
            Init();
            AddNotRemovableQualitiesAndDrawbacks();
        }

        private void Init()
        {
            nbTraits = 0;
        }

        private void AddNotRemovableQualitiesAndDrawbacks()
        {
            foreach (Quality quality in qualitiesNotRemovables)
            {
                AddQuality(true, quality);
            }
            foreach (Drawback drawback in drawbacksNotRemovables)
            {
                AddDrawback(true, drawback);
            }
            RefreshQualitiesAndDrawbacks();
        }

        public void AddQuality()
        {
            AddQuality(false);
        }

        public void AddDrawback()
        {
            AddDrawback(false);
        }

        private void AddQuality(bool notRemovable, Quality quality = null)
        {
            if (nbTraits < maxNbTraits)
            {
                nbTraits++;
                if (quality == null) quality = creationService.Qualities.ElementAt(qualitiesDropDowns.value);
                GameObject item = Instantiate(itemPrefab, qualitiesContent);
                item.name = quality.name;
                item.GetComponentInChildren<TextMeshProUGUI>().text = quality.name;
                item.GetComponentInChildren<RemoveButton>().qualitiesDrawbacksSelector = this;
                if (notRemovable) Destroy(item.GetComponentInChildren<Button>().gameObject);
                qualitiesDefaultsExpositionBehavior.AddCatQuality(quality);
            }
            RefreshQualitiesAndDrawbacks();
        }

        private void AddDrawback(bool notRemovable, Drawback drawback = null)
        {
            if (nbTraits < maxNbTraits)
            {
                nbTraits++;
                if (drawback == null) drawback = creationService.Drawbacks.ElementAt(drawbacksDropDowns.value);
                GameObject item = Instantiate(itemPrefab, drawbacksContent);
                item.name = drawback.name;
                item.GetComponentInChildren<TextMeshProUGUI>().text = drawback.name;
                item.GetComponentInChildren<RemoveButton>().qualitiesDrawbacksSelector = this;
                if (notRemovable) Destroy(item.GetComponentInChildren<Button>().gameObject);
                qualitiesDefaultsExpositionBehavior.AddCatDrawback(drawback);
            }
            RefreshQualitiesAndDrawbacks();
        }

        internal void RemoveSelectedItem(string id, GameObject objectToRemove)
        {
            nbTraits--;
            IEnumerable<Quality> selectQuality = qualitiesDefaultsExpositionBehavior.GetQualities().Where(q => q.name == id);
            if (selectQuality.Any())
            {
                Quality qualityToRemove = selectQuality.ElementAt(0);
                if (qualityToRemove != null)
                {
                    qualitiesDefaultsExpositionBehavior.RemoveCatQuality(qualityToRemove);
                }
            }
            IEnumerable<Drawback> selectDrawback = qualitiesDefaultsExpositionBehavior.GetDrawbacks().Where(d => d.name == id);
            if (selectDrawback.Any())
            {
                Drawback drawbackToRemove = selectDrawback.ElementAt(0);
                if (drawbackToRemove != null)
                {
                    qualitiesDefaultsExpositionBehavior.RemoveCatDrawback(drawbackToRemove);
                }
            }
            Destroy(objectToRemove);
            RefreshQualitiesAndDrawbacks();
        }

        private void RefreshQualitiesAndDrawbacks()
        {
            //Qualités disponibles : creationService.Qualities
            //Qualités sélectionnées : qualitiesDefaultsExpositionBehavior.GetQualities()
            qualitiesDropDowns.options.Clear();
            IEnumerable<Quality> differencesQualities = creationService.Qualities.Except(qualitiesDefaultsExpositionBehavior.GetQualities());
            foreach (Quality quality in differencesQualities)
            {
                qualitiesDropDowns.options.Add(new TMP_Dropdown.OptionData(quality.name));
            }
            qualitiesDropDowns.RefreshShownValue();
            //Qualités disponibles : creationService.Drawbacks
            //Qualités sélectionnées : qualitiesDefaultsExpositionBehavior.GetDrawbacks()
            drawbacksDropDowns.options.Clear();
            IEnumerable<Drawback> differencesDrawbacks = creationService.Drawbacks.Except(qualitiesDefaultsExpositionBehavior.GetDrawbacks());
            foreach (Drawback drawback in differencesDrawbacks)
            {
                drawbacksDropDowns.options.Add(new TMP_Dropdown.OptionData(drawback.name));
            }
            drawbacksDropDowns.RefreshShownValue();
            TryDisableButtons();
        }

        private void TryDisableButtons()
        {
            bool enable = nbTraits < maxNbTraits;
            qualityAddButton.interactable = enable;
            drawbackAddButton.interactable = enable;
        }
    }
}
