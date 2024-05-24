using UnityEngine;

namespace CatAclysm.Character
{
    [CreateAssetMenu(fileName = "PlayTimeEffect", menuName = "Data/Effects/PlayTimeEffect")]
    public class PlayTimeEffect : Effect
    {
        [SerializeField]
        private string description;

        public override void Apply(Cat cat)
        {
            // Do nothing at character creation
        }
    }
}