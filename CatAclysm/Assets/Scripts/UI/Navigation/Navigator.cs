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
                gameObject.SetActive(false);
                next.gameObject.SetActive(true);
            }
        }

        public void MoveToPrevious()
        { 
            if (previous != null) 
            {
                gameObject.SetActive(false);
                previous.gameObject.SetActive(true);
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
