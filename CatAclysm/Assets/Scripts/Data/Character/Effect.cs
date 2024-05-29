using System;
using UnityEngine;

namespace CatAclysm.Character
{ 
    public abstract class Effect : ScriptableObject
    {
        public abstract void Apply(Cat cat);
        public abstract void Revert(Cat cat);

        public abstract bool CanApply(Cat cat);
    }
}
