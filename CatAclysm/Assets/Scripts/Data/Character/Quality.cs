using UnityEngine;

namespace CatAclysm.Character
{
    [CreateAssetMenu(fileName = "Quality", menuName = "Data/Quality")]
    public class Quality : Trait
    {
        protected override string GetTypeName() => "Qualité";
    }
}
