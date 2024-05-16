namespace CatAclysm.Character.Builder
{
    public abstract class CharacterBuilderBase
    {
        protected CharacterSheet characterSheet = new();

        public CharacterSheet BuildCharacter() => characterSheet;
    }
}
