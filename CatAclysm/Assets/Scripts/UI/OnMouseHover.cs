using UnityEngine;
using UnityEngine.EventSystems;

namespace CatAclysm.UI
{
    public class MyClass : MonoBehaviour, IPointerEnterHandler
    {
        [SerializeField] private GameObject objectToShow;

        public void OnPointerEnter(PointerEventData eventData)
        {
            objectToShow.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            objectToShow.SetActive(false);
        }
    }
}