using CatAclysm.Character;
using CatAclysm.Events;
using UnityEngine;
using UnityEngine.Events;

namespace CatAclysm.Behavior
{
    public class CatExpositionBehavior : MonoBehaviour
    {
        [SerializeField]
        private Cat cat;

        [SerializeField]
        private UnityEvent<string> catNameChanged;

        [SerializeField]
        private UnityEvent<int> griffeChanged;

        [SerializeField]
        private UnityEvent<int> poilChanged;

        private void OnEnable()
        {
            cat.NameChanged += Cat_NameChanged;
            cat.GriffeChanged += Cat_GriffeChanged;
            cat.PoilChanged += Cat_PoilChanged;
        }

        

        private void OnDisable()
        {
            cat.NameChanged -= Cat_NameChanged;
            cat.GriffeChanged -= Cat_GriffeChanged;
            cat.PoilChanged -= Cat_PoilChanged;
        }

        #region Callbacks

        private void Cat_NameChanged(object sender, StringEventArgs e)
            => catNameChanged.Invoke(e.Text);

        private void Cat_GriffeChanged(object sender, IntEventArgs e)
            => griffeChanged.Invoke(e.Value);

        private void Cat_PoilChanged(object sender, IntEventArgs e)
            => poilChanged?.Invoke(e.Value);

        #endregion
    }
}
