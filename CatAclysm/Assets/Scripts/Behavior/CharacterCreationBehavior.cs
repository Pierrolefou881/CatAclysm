using CatAclysm.Services;
using UnityEngine;

namespace CatAclysm.Behavior
{
    public class CharacterCreationBehavior : MonoBehaviour
    {
        [SerializeField]
        private CharacterCreationService creationService;

        public void CreateCat() => creationService.InitCat();
    }
}
