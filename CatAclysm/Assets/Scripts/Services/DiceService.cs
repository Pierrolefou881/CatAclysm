using UnityEngine;

namespace CatAclysm.Services
{
    [CreateAssetMenu(fileName = "DicesService", menuName = "Services/Dice")]
    public class DiceService : ScriptableObject
    {
        public int Roll(int faces, int numberOfRolls = 1)
            => numberOfRolls == 1 ? Random.Range(1, faces) : Roll(faces, numberOfRolls - 1) + Random.Range(1, faces);
    }
}