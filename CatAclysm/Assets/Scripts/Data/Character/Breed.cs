using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CatAclysm.Character
{
    [CreateAssetMenu(fileName = "Breed", menuName = "Data/Breeds")]
    public class Breed : ScriptableObject
    {
        public IEnumerable<Quality> Qualities => qualities.AsEnumerable();
        [SerializeField]
        private List<Quality> qualities = new();

        public IEnumerable<Drawback> Drawbacks => drawbacks.AsEnumerable(); 
        [SerializeField]
        private List<Drawback> drawbacks = new();

        [SerializeField]
        private Sprite sprite;
    }
}
