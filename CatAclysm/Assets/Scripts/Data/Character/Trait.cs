using UnityEngine;

namespace CatAclysm.Character
{
    public abstract class Trait : ScriptableObject
    {
        [SerializeField]
        [Range(-8, 4)]
        private int gain;

        [SerializeField]
        private Effect effect;

        public bool CanApply(Cat cat) => effect.CanApply(cat);
        public void Apply(Cat cat) => effect.Apply(cat);
        // TODO remove trait ???
    }
}
