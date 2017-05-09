namespace UnitedGameDevelopment.Data
{
    public class Data
    {
        private static UnitedGameDevelopmentContext context;

        public static UnitedGameDevelopmentContext Context =>
            context ?? (context = new UnitedGameDevelopmentContext());
    }
}