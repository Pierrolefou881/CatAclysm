using CatAclysm.Character;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CatAclysm.Behavior
{
    public class CatQualitiesDefaultsExpositionBehavior : MonoBehaviour
    {
        [SerializeField]
        private Cat cat;

        internal IEnumerable<Quality> GetQualities()
        {
            return cat.Qualities.AsEnumerable();
        }

        internal IEnumerable<Drawback> GetDrawbacks()
        {
            return cat.Drawbacks.AsEnumerable();
        }

        public void AddCatQuality(Quality quality)
        {
            if (!cat.Qualities.Contains(quality))
            {
                cat.Qualities.Add(quality);
            }
        }

        public bool RemoveCatQuality(Quality quality) => cat.Qualities.Remove(quality);

        public void AddCatDrawback(Drawback drawbacks)
        {
            if (!cat.Drawbacks.Contains(drawbacks))
            {
                cat.Drawbacks.Add(drawbacks);
            }
        }

        public bool RemoveCatDrawback(Drawback drawbacks) => cat.Drawbacks.Remove(drawbacks);
    }
}