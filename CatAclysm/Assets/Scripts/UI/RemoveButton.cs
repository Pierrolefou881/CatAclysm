using CatAclysm.UI;
using UnityEngine;

public class RemoveButton : MonoBehaviour
{
    internal QualitiesDrawbacksSelector qualitiesDrawbacksSelector;

    public void Remove()
    {
        GameObject trait = transform.parent.gameObject;
        qualitiesDrawbacksSelector.RemoveSelectedItem(trait.name, trait);
    }
}
