using UnityEngine;

namespace CatAclysm.Character
{
    [CreateAssetMenu(fileName = "Drawback", menuName = "Data/Drawback")]
    public class Drawback : Trait
    {
        protected override string GetTypeName() => "Défaut";
    }
}
