using System;
using UnityEngine;

namespace CatAclysm.Character
{ 
    public enum Characteristics
    {
        None,
        Griffe,
        Poil,
        Oeil,
        Queue,
        Caresse,
        Ronronnement,
        Coussinet,
        Vibirisse
    }

    public abstract class Effect : ScriptableObject
    {
        public abstract void Apply(Cat cat);
    }
}
