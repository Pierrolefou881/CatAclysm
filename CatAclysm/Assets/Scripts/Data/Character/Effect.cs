using System;
using UnityEngine;

namespace CatAclysm.Character
{
    //[Flags]
    //public enum CharacteristicMask
    //{
    //    None = 0,               // 0000
    //    Griffe = 1 << 0,        // 0001
    //    Poil = 1 << 1,          // 0010
    //    Oeil = 1 << 2,          // 0100
    //    Queue = 1 << 3,         // 1000
    //    Caresse = 1 << 4,       // 0001
    //    Ronronnement = 1 << 5,  // 0010
    //    Coussinet = 1 << 6,     // 0100
    //    Vibirisse = 1 << 7,     // 1000
    //    All = ~0                // 1111
    //}

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
