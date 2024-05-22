using CatAclysm.Character;
using CatAclysm.Character.Library;
using UnityEngine;

namespace CatAclysm.Services
{
    [CreateAssetMenu(fileName = "CharacterCreationService", menuName ="Services/CharacterCreationService")]
    public class CharacterCreationService : ScriptableObject
    {
        [SerializeField]
        private CharacterAttributesLibrary characterAttributesLibrary;

        [SerializeField]
        private Cat theCat;

        private void OnEnable()
        {
            InitCat(); 
        }

        [ContextMenu("Create new cat")]
        private void InitCat()
        { 
            theCat.Init(characterAttributesLibrary.Skills, GenerateName(), GenerateLineage());
        }

        private string GenerateLineage() => characterAttributesLibrary.GenerateLineage();

        private string GenerateName() => characterAttributesLibrary.GenerateName();

        public int ConvertHumanAgeToCat(int humanAge) => Mathf.RoundToInt(humanAge / 5.0f);
    }
}
