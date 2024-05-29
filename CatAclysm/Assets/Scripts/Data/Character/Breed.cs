using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            foreach (var q in qualities)
            { 
                q.Apply(cat);
                cat.Qualities.Add(q);
            }
            foreach (var d in drawbacks)
            { 
                d.Apply(cat);
                cat.Drawbacks.Add(d);
            }
        }
        
        public void Revert(Cat cat) 
        {
            foreach (var q in Qualities)
            { 
                q.Revert(cat); 
                cat.Qualities.Remove(q);
            }

            foreach (var d in drawbacks)
            { 
                d.Revert(cat);
                cat.Drawbacks.Remove(d);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            if (qualities.Count > 0)
            {
                sb.AppendLine("<b><u>Qualité(s) :</u></b>");
                qualities.ForEach(q => sb.AppendLine(q.ToString()));
            }
            if (drawbacks.Count > 0)
            {
                sb.AppendLine("<b><u>Défaut(s) :</u></b>");
                drawbacks.ForEach(d => sb.AppendLine(d.ToString()));
            }
            return sb.ToString();
        }
    }
}
