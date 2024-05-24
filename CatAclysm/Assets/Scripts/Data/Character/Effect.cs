using System;
using UnityEngine;

namespace CatAclysm.Character
{ 
    public abstract class Effect : ScriptableObject
    {
        public abstract void Apply(Cat cat);
        public abstract void Revert(Cat cat);

        public virtual bool CanApply(Cat cat) => true;
    }
}
