using UnityEngine;

namespace CatAclysm.Services
{
    [CreateAssetMenu(fileName = "DicesService", menuName = "Service/Dice")]
    public class DiceService : ScriptableObject
    {
        public int LaunchD10(int number = 1)
        {
            int result = 0;
            for (int i = 0; i < number; i++)
            {
                result += Random.Range(1, 10);
            }
            return result;
        }
        public int LaunchD6(int number = 1)
        {
            int result = 0;
            for (int i = 0; i < number; i++)
            {
                result += Random.Range(1, 6);
            }
            return result;
        }

        public int LaunchD20(int number = 1)
        {
            int result = 0;
            for (int i = 0; i < number; i++)
            {
                result += Random.Range(1, 20);
            }
            return result;
        }
    }
}
