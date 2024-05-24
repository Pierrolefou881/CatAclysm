using System;
using UnityEngine;

namespace CatAclysm.Character
{ 
    public abstract class Effect : ScriptableObject
    {
        public abstract void Apply(Cat cat);

        public virtual bool CanApply(Cat cat) => true;
    }
}
