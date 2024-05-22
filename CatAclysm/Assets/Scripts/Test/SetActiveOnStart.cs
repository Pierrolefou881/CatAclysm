using UnityEngine;

namespace CatAclysm.Test
{
    public class SetActiveOnStart : MonoBehaviour
    {
        [SerializeField]
        private bool isActive;
        void Start() => gameObject.SetActive(isActive);
    }
}
