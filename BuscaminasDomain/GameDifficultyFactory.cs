namespace BuscaminasDomain
{
    public class GameDifficultyFactory
    {

        public static GameDifficulty CreateEasyGame()
        {
            return new GameDifficulty("Principiante", 8, 8, 10);
        }

        public static GameDifficulty CreateIntermediateGame()
        {
            return new GameDifficulty("Intermedia", 16, 16, 40);
        }

        public static GameDifficulty CreateHardGame()
        {
            return new GameDifficulty("Experto", 30, 16, 99);
        }
    }
}
