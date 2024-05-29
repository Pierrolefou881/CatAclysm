namespace CatAclysm.UI.Navigation
{
    public class ElCaptainBugaloo : Navigator
    {
        public override void ReturnToStart()
        {
            base.ReturnToStart();
            gameObject.SetActive(true);
        }
    }
}