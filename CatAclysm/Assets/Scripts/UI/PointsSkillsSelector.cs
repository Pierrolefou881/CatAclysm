using CatAclysm.Behavior;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CatAclysm.UI
{
    public class CharacteristicsSelector : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI physicSelectedCharacteristic, mentalSelectedCharacteristic;
        [SerializeField] private List<TextMeshProUGUI> physicCharacteristics, mentalCharacteristics;
        [SerializeField] private TextMeshProUGUI luckCharacteristic;
        [SerializeField] private TextMeshProUGUI remainingPoints;
        [SerializeField] private Button decrPhysic, incrPhysic;
        [SerializeField] private Button decrMental, incrMental;
        [SerializeField] private Button decrLuck, incrLuck;

        [SerializeField] private CatBaseStatExpositionBehavior catBaseStatExpositionBehavior;

        private int selectedPhysicCharacteristic, selectedMentalCharacteristic;

        public enum PhysicCharacteristics
        {
            Griffe,
            Poil,
            Oeil,
            Queue
        }
        public enum MentalCharacteristics
        {
            Caresse,
            Ronronnement,
            Coussinet,
            Vibrisse
        }

        public void SelectPhysicSkill(bool prev)
        {
            selectedPhysicCharacteristic = GetSelectedNumber(selectedPhysicCharacteristic, prev, physicCharacteristics.Count);
            physicSelectedCharacteristic.text = ((PhysicCharacteristics)selectedPhysicCharacteristic).ToString();
        }

        public void SelectMentalSkill(bool prev)
        {
            selectedMentalCharacteristic = GetSelectedNumber(selectedMentalCharacteristic, prev, mentalCharacteristics.Count);
            mentalSelectedCharacteristic.text = ((MentalCharacteristics)selectedMentalCharacteristic).ToString();
        }

        public int GetSelectedNumber(int selectedCharacteristic, bool prev, int count)
        {
            int nb = selectedCharacteristic + (prev ? -1 : 1);
            if (nb < 0)
            {
                return count - 1;
            }
            else if (nb >= count)
            {
                return 0;
            }
            else
            {
                return nb;
            }
        }

        public void ModifyPhysicValue(bool decrement)
        {
            int newValue = GetNewCharacteristicValue(physicCharacteristics[selectedPhysicCharacteristic].text, decrement);
            switch((PhysicCharacteristics)selectedPhysicCharacteristic)
            {
                case PhysicCharacteristics.Griffe:
                    catBaseStatExpositionBehavior.SetGriffe(newValue); 
                    break;
                case PhysicCharacteristics.Poil:
                    catBaseStatExpositionBehavior.SetPoil(newValue); 
                    break;
                case PhysicCharacteristics.Oeil:
                    catBaseStatExpositionBehavior.SetOeil(newValue); 
                    break;
                case PhysicCharacteristics.Queue:
                    catBaseStatExpositionBehavior.SetQueue(newValue); 
                    break;
            }
        }

        public void ModifyMentalValue(bool decrement)
        {
            int newValue = GetNewCharacteristicValue(mentalCharacteristics[selectedMentalCharacteristic].text, decrement);
            switch ((MentalCharacteristics)selectedMentalCharacteristic)
            {
                case MentalCharacteristics.Caresse:
                    catBaseStatExpositionBehavior.SetCaresse(newValue); break;
                case MentalCharacteristics.Ronronnement:
                    catBaseStatExpositionBehavior.SetRonronnement(newValue); break;
                case MentalCharacteristics.Coussinet:
                    catBaseStatExpositionBehavior.SetCoussinet(newValue); break;
                case MentalCharacteristics.Vibrisse:
                    catBaseStatExpositionBehavior.SetVibrisse(newValue); break;
            }
        }

        public void ModifyChanceValue(bool decrement)
        {
            catBaseStatExpositionBehavior.SetLuck(GetNewCharacteristicValue(luckCharacteristic.text, decrement, true));
        }

        private int GetNewCharacteristicValue(string text, bool decrement, bool isLuck = false)
        {
            try
            {
                int value = int.Parse(text);
                if ((isLuck && !decrement && (value >= 3)) || (!decrement && (value >= 5)))
                {
                    AlertMaxValue();
                    return value;
                }
                else if (decrement && (value <= 1))
                {
                    AlertMinValue();
                    return value;
                }
                return value + (decrement ? -1 : 1);
            }
            catch
            {
                return 1;
            }
        }

        private void AlertMaxValue()
        {
            //Max Value
        }

        private void AlertMinValue()
        {
            //Min Value
        }

        public void CheckAndDisablePhysicButton()
        {
            int.TryParse(physicCharacteristics[selectedPhysicCharacteristic].text, out int JenAiMarreDeUnity);
            decrPhysic.gameObject.SetActive(JenAiMarreDeUnity > 1);
            incrPhysic.gameObject.SetActive(JenAiMarreDeUnity <= 5);
        }

        public void CheckAndDisableMentalButton()
        {
            int.TryParse(mentalCharacteristics[selectedMentalCharacteristic].text, out int JenAiMarreDeUnity);
            decrMental.gameObject.SetActive(JenAiMarreDeUnity > 1);
            incrMental.gameObject.SetActive(JenAiMarreDeUnity <= 5);
        }

        public void CheckAndDisableLuckButton()
        {
            int.TryParse(luckCharacteristic.text, out int JenAiMarreDeUnity);
            decrLuck.gameObject.SetActive(JenAiMarreDeUnity > 1);
            incrLuck.gameObject.SetActive(JenAiMarreDeUnity <= 3);
        }

        public void CheckAndDisableIncrButton(string nbPointsTxt)
        {
            int.TryParse(nbPointsTxt, out int nbPoints);
            bool disable = nbPoints <= 0;
            incrPhysic.gameObject.SetActive(disable);
            incrMental.gameObject.SetActive(disable);
            incrLuck.gameObject.SetActive(disable);
        }

        public void ResetSkills()
        {
            foreach (TextMeshProUGUI uGUI in physicCharacteristics.Concat(mentalCharacteristics).Append(luckCharacteristic))
            {
                uGUI.text = "1";
            }
            catBaseStatExpositionBehavior.SetGriffe(1);
            catBaseStatExpositionBehavior.SetPoil(1);
            catBaseStatExpositionBehavior.SetQueue(1);
            catBaseStatExpositionBehavior.SetOeil(1);
            catBaseStatExpositionBehavior.SetLuck(1);
            catBaseStatExpositionBehavior.SetCoussinet(1);
            catBaseStatExpositionBehavior.SetVibrisse(1);
            catBaseStatExpositionBehavior.SetRonronnement(1);
            catBaseStatExpositionBehavior.SetCaresse(1);
            CheckAndDisablePhysicButton();
            CheckAndDisableMentalButton();
            CheckAndDisableLuckButton();
        }

        private void Start()
        {
            selectedMentalCharacteristic = 0;
            selectedPhysicCharacteristic = 0;
            ResetSkills();
        }
    }
}
