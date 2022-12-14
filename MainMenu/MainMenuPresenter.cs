using BuscaminasAuth;
using BuscaminasDomain;
using BuscaminasDomain.GameLoader;
using BuscaminasDomain.GameRules.Factories;
using BuscaminasDomain.GameRules.Factories.Restorers;
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
        void ChangeUserMenuVisibility(bool isVisible);
        void SetCurrentUserName(string userName);
        void LaunchGame(IGameFactory gameFactory, GameDifficulty difficulty);
        void ShowSinglePlayerInProgressGames(List<InProgressGameViewItem> items); 
        void ShowMultiPlayerRooms(List<InProgressGameViewItem> items);
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
        private IGamesLoader multiPlayerRoomsLoader;
        private IGamesLoader multiPlayerInProgressGamesLoader;

        private MultiplayerGamePlayerAdder multiplayerGamePlayerAdder;

        public MainMenuPresenter(IMainMenuForm form)
        {
            this.form = form;
            this.auth = Authentication.GetInstance();
            this.singlePlayerGamesLoader = new SinglePlayerGameLoader();
            this.multiPlayerRoomsLoader = new MultiplayerRoomsLoader();
            this.multiPlayerInProgressGamesLoader = new MultiplayerInProgressGamesLoader();
            this.multiplayerGamePlayerAdder = new MultiplayerGamePlayerAdder();
        }

        public void OnStartForm()
        {
            form.ChangeUserLoggedButtonEnable(auth.UserLogged);
            form.ChangeUserMenuVisibility(auth.UserLogged);
            if (auth.UserLogged)
            {
                form.SetCurrentUserName(auth.UserName);
            }
        }

        public void ShowSinglePlayerGames()
        {
            LoadCurrentSinglePlayerGames();
        }

        public void ShowMultiplayerOpenRooms()
        {
            var inProgressGames = multiPlayerRoomsLoader.GetInProgressGames();

            List<InProgressGameViewItem> mpgViewItems = new List<InProgressGameViewItem>();
            foreach (BuscaminasBE.InProgressGame game in inProgressGames)
            {
                string title = "Multiplayer - " + game.BoardWidth + "x" + game.BoardHeight;
                InProgressGameViewItem viewItem = new InProgressGameViewItem(game.GameId, title);
                mpgViewItems.Add(viewItem);
            }
            form.ShowMultiPlayerRooms(mpgViewItems);
        }

        public void ShowMultiplayerGamesInProgess()
        {
            var inProgressGames = multiPlayerInProgressGamesLoader.GetInProgressGames();

            List<InProgressGameViewItem> mpgViewItems = new List<InProgressGameViewItem>();
            foreach (BuscaminasBE.InProgressGame game in inProgressGames)
            {
                string playerTurn;
                if (string.IsNullOrEmpty(game.GameOwnerName))
                {
                    playerTurn = "Esperando jugador";
                } else
                {
                    playerTurn = game.GameOwnerName;
                }

                string title = "Multiplayer - " + game.BoardWidth + "x" + game.BoardHeight + " - Turno de: " + playerTurn;
                InProgressGameViewItem viewItem = new InProgressGameViewItem(game.GameId, title);
                mpgViewItems.Add(viewItem);
            }
            form.ShowMultiPlayerRooms(mpgViewItems);
        }

        public void StartNewSinglePlayerGame(GameCheckBoxDifficulty difficulty)
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

        public void StartNewMultiplayerGame(GameCheckBoxDifficulty difficulty)
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
            form.LaunchGame(new MultiplayerGameFactory(), gameDifficulty);
        }

        public void JoinMultiplayerGame(InProgressGameViewItem game)
        { 
            if (game == null)
            {
                return;
            }
            try
            {
                BuscaminasBE.MultiplayerGame multiplayerGame = multiplayerGamePlayerAdder.AddPlayerToGame(game.GameId);
                LaunchMultiplayerGame(multiplayerGame);
            }
            catch (Exception ex)
            {
                form.ShowMessage(ex.Message);
            }
        }

        public void OnUserLoggedInOrRegistered()
        {
            form.ChangeUserLoggedButtonEnable(true);
            form.ChangeUserMenuVisibility(true);
            form.SetCurrentUserName(auth.UserName);
        }

        public void RefreshSinglePlayerGames()
        {
            LoadCurrentSinglePlayerGames();
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
            GameDifficulty gameDifficulty = GameDifficultyFactory.CreateFromBoardSize(game.Board.Width, game.Board.Height);
            form.LaunchGame(spgRestorer, gameDifficulty);
        }

        public void LoadMultiplayerGame(InProgressGameViewItem selectedGameItem)
        {
            if (selectedGameItem == null)
            {
                return;
            }
            try
            {
                BuscaminasBE.MultiplayerGame game = (BuscaminasBE.MultiplayerGame) multiPlayerInProgressGamesLoader.LoadGame(selectedGameItem.GameId);
                if (game == null)
                {
                    form.ShowMessage("Este juego ha finalizado!");
                    return;
                } 
                LaunchMultiplayerGame(game);
            } catch(Exception ex)
            {
                form.ShowMessage(ex.Message);
            }
        }

        public void Logout()
        {
            Authentication.GetInstance().Logout();
            form.ChangeUserLoggedButtonEnable(false);
            form.ChangeUserMenuVisibility(false);
        }

        private void LoadCurrentSinglePlayerGames()
        {
            var inProgressGames = singlePlayerGamesLoader.GetInProgressGames();

            List<InProgressGameViewItem> spgViewItems = new List<InProgressGameViewItem>();
            foreach (BuscaminasBE.InProgressGame game in inProgressGames)
            {
                string title = "Single player - " + game.BoardWidth + "x" + game.BoardHeight +
                    " - " + game.RemaningMines + " minas restantes";
                InProgressGameViewItem viewItem = new InProgressGameViewItem(game.GameId, title);
                spgViewItems.Add(viewItem);
            }
            form.ShowSinglePlayerInProgressGames(spgViewItems);
        }

        private void LaunchMultiplayerGame(BuscaminasBE.MultiplayerGame game)
        {
            GameRestorer gameRestorer = new MultiplayerGameRestorer(game);
            GameDifficulty gameDifficulty = GameDifficultyFactory.CreateFromBoardSize(game.Board.Width, game.Board.Height);
            form.LaunchGame(gameRestorer, gameDifficulty);
        }
    }
}
