namespace CatAclysm.Character.Builder
{
    public class CharacterBuilderBase
    {
        private readonly CharacterSheet characterSheet = new();

        public CharacterBuilderBase SetBaseStats(BaseStats stats) 
        {
            characterSheet.BaseStats = stats;
            return this;
        }

        public CharacterSheet BuildCharacter() => characterSheet;
    }
}
