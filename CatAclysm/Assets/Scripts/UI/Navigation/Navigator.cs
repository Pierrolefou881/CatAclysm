using UnityEngine;

namespace CatAclysm.UI.Navigation
{
    public class Navigator : MonoBehaviour
    {
        [SerializeField]
        private bool isActive;

        [SerializeField]
        private Navigator previous;

        [SerializeField]
        protected Navigator next;

        private void Start() => gameObject.SetActive(isActive);

        public void GotToNext()
        { 
            if (next != null) 
            {
                next.gameObject.SetActive(true);
                gameObject.SetActive(false);
            }
        }

        public void MoveToPrevious()
        { 
            if (previous != null) 
            {
                previous.gameObject.SetActive(true);
                gameObject.SetActive(false);
            }
        }

        public virtual void ReturnToStart()
        {
            gameObject.SetActive(false);
            if (next != null) 
            {
                next.ReturnToStart();
            }
        }
    }
}
