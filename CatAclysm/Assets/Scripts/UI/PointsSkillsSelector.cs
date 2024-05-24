using CatAclysm.Behavior;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillSelector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI physicSelectedSkill, mentalSelectedSkill;
    [SerializeField] private List<TextMeshProUGUI> physicSkills, mentalSkills;
    [SerializeField] private TextMeshProUGUI chanceSkill;

    [SerializeField] private CharacterCreationBehavior characterCreationBehavior;

    private int selectedPhysicSkill, selectedMentalSkill;

    public enum PhysicSkills
    {
        Griffe,
        Poil,
        Oeil,
        Queue
    }
    public enum MentalSkills
    {
        Caresse,
        Ronronnement,
        Coussinet,
        Vibrisse
    }

    public void SelectPhysicSkill(PhysicSkills skill)
    {
        selectedPhysicSkill = (int) skill;
    }

    public void SelectMentalSkill(MentalSkills skill)
    {
        selectedMentalSkill = (int) skill;
    }

    public void ModifyPhysicValue(bool decrement)
    {
        Debug.Log($"{(PhysicSkills) selectedPhysicSkill} {(decrement?-1:1)}");
    }

    public void ModifyMentalValue(bool decrement)
    {
        Debug.Log($"{(MentalSkills)selectedPhysicSkill} {(decrement ? -1 : 1)}");
    }

    public void ModifyChanceValue(bool decrement)
    {
        Debug.Log($"Chance  {(decrement ? -1 : 1)}");
    }

    private void Start()
    {
        
    }
}
