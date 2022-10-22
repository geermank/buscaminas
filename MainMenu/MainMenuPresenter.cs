using BuscaminasAuth;
using BuscaminasDomain;
using BuscaminasDomain.GameRules.Factories;

namespace Buscaminas.MainMenu
{
    enum GameCheckBoxDifficulty
    {
        EASY,
        INTERMEDIATE,
        HARD
    }

    interface IMainMenuForm
    {
        void ChangeMultiplayerButtonEnable(bool isEnable);
        void SetCurrentUserName(string userName);
        void LaunchGame(IGameFactory gameFactory, GameDifficulty difficulty);
    }

    internal class MainMenuPresenter
    {
        private IMainMenuForm form;
        private Authentication auth;
        
        public MainMenuPresenter(IMainMenuForm form)
        {
            this.form = form;
            this.auth = Authentication.GetInstance();
        }

        public void OnStartForm()
        {
            form.ChangeMultiplayerButtonEnable(auth.UserLogged);
            if (auth.UserLogged)
            {
                form.SetCurrentUserName(auth.UserName);
            }
        }

        public void StartSingleGame(GameCheckBoxDifficulty difficulty)
        {
            GameDifficulty gameDifficulty;
            if (difficulty == GameCheckBoxDifficulty.EASY)
            {
                gameDifficulty = GameDifficultyFactory.CreateEasyGame();
            }
            else if (difficulty == GameCheckBoxDifficulty.INTERMEDIATE)
            {
                gameDifficulty = GameDifficultyFactory.CreateIntermediateGame();
            }
            else
            {
                gameDifficulty = GameDifficultyFactory.CreateHardGame();
            }
            form.LaunchGame(new SinglePlayerGameFactory(), gameDifficulty);
        }

        public void StartMultiplayerGame()
        {
            form.LaunchGame(
                new MultiplayerGameFactory(),
                GameDifficultyFactory.CreateHardGame()
            );
        }

        public void OnUserLoggedInOrRegistered()
        {
            form.ChangeMultiplayerButtonEnable(true);
            form.SetCurrentUserName(auth.UserName);
        }
    }
}
