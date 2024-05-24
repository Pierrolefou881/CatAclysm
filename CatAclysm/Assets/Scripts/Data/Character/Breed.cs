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

        public bool CanApply(Cat cat) => qualities.TrueForAll(q => q.CanApply(cat)) && drawbacks.TrueForAll(d => d.CanApply(cat));
        public void Apply(Cat cat)
        {
            qualities.ForEach(q => q.Apply(cat));
            drawbacks.ForEach(d => d.Apply(cat));
        }
        
        public void Revert(Cat cat) 
        {
            qualities.ForEach(q => q.Revert(cat));
            drawbacks.ForEach(d => d.Revert(cat));
        }
    }
}
