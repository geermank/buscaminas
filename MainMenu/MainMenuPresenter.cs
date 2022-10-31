using BuscaminasAuth;
using BuscaminasDomain;
using BuscaminasDomain.GameLoader;
using BuscaminasDomain.GameRules;
using BuscaminasDomain.GameRules.Factories;
using System;
using System.Collections.Generic;

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
        void ChangeUserLoggedButtonEnable(bool isEnable);
        void SetCurrentUserName(string userName);
        void LaunchGame(IGameFactory gameFactory, GameDifficulty difficulty);
        void ShowSinglePlayerInProgressGames(List<InProgressGameViewItem> items);
        void ShowMessage(string message);
    }

    public class InProgressGameViewItem
    {
        private int gameId;

        public int GameId { get { return gameId; } }

        private string title;

        public string Title { get { return title; } }

        public InProgressGameViewItem(int gameId, string title)
        {
            this.gameId = gameId;
            this.title = title;
        }

        public override string ToString()
        {
            return title;
        }
    }

    internal class MainMenuPresenter
    {
        private IMainMenuForm form;
        private Authentication auth;

        private IGamesLoader singlePlayerGamesLoader;
        private IGamesLoader multiPlayerGamesLoader;

        public MainMenuPresenter(IMainMenuForm form)
        {
            this.form = form;
            this.auth = Authentication.GetInstance();
            this.singlePlayerGamesLoader = new SinglePlayerGameLoader();
        }

        public void OnStartForm()
        {
            form.ChangeUserLoggedButtonEnable(auth.UserLogged);
            if (auth.UserLogged)
            {
                form.SetCurrentUserName(auth.UserName);
                LoadCurrentSinglePlayerGames();
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
            form.ChangeUserLoggedButtonEnable(true);
            form.SetCurrentUserName(auth.UserName);
            LoadCurrentSinglePlayerGames();
        }

        public void RefreshSinglePlayerGames()
        {
            LoadCurrentSinglePlayerGames();
        }

        private void LoadCurrentSinglePlayerGames()
        {
            var inProgressGames = singlePlayerGamesLoader.GetInProgressGames();

            List<InProgressGameViewItem> spgViewItems = new List<InProgressGameViewItem>();
            foreach(BuscaminasBE.InProgressGame game in inProgressGames)
            {
                string title = "Single player - " + game.BoardWidth + "x" + game.BoardHeight + 
                    " - " + game.RemaningMines + " minas restantes"; 
                InProgressGameViewItem viewItem = new InProgressGameViewItem(game.GameId, title);
                spgViewItems.Add(viewItem);
            }
            form.ShowSinglePlayerInProgressGames(spgViewItems);
        }

        public void ContinueSinglePlayerGame(InProgressGameViewItem selectedGame)
        { 
            if (selectedGame == null)
            {
                return;
            }
            BuscaminasBE.SinglePlayerGame game = (BuscaminasBE.SinglePlayerGame) singlePlayerGamesLoader.LoadGame(selectedGame.GameId);
            if (game == null)
            {
                form.ShowMessage("Este juego ha finalizado!");
                LoadCurrentSinglePlayerGames();
                return;
            }
            
            SinglePlayerGameRestorer spgRestorer = new SinglePlayerGameRestorer(game);
            GameDifficulty gameDifficulty = GameDifficultyFactory.GetFromBoardSize(game.Board.Width, game.Board.Height);
            form.LaunchGame(spgRestorer, gameDifficulty);
        }
    }
}
