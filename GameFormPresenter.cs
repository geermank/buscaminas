﻿using BuscaminasAuth;
using BuscaminasDomain;
using BuscaminasDomain.GameRules;
using BuscaminasDomain.GameRules.Factories;

namespace Buscaminas
{
    internal interface IGameForm
    {
        void ConfigureFaceButton(int width, int height, int x, int y);
        void SetFaceButtonImage(string path);
        void ConfigureBoardView(int headerWidth, int headerHeight, int panelWidth, int panelHeight);
        void ConfigureCellViews(int width, int height);
        void SetMinesLeft(string minesLeft);
        void SetTimePlayed(string timePlayedInSeconds);
        void StartTimer();
        void StopTimer();
        void ChangeCellsPanelEnable(bool isEnabled);
        void ShowExploitedMine(int x, int y);
        void ShowNormalMine(int x, int y);
        void ShowMineCrossedOut(int x, int y);
        void ShowEmptyCell(int x, int y);
        void ShowNumber(int x, int y, int number);
        void ShowFlag(int x, int y);
        void RemoveFlag(int x, int y);
        void ResetCellViews(int width, int height);
    }

    internal class GameFormPresenter : Game.IGameListener
    {
        private IGameForm form;

        private Game currentGame;
        private GameDifficulty gameDifficulty;
        private IGameFactory gameFactory;

        private Authentication authentication;

        public GameFormPresenter(IGameForm form)
        {
            this.form = form;
        }

        public void SetGameDifficulty(GameDifficulty gameDifficulty)
        {
            this.gameDifficulty = gameDifficulty;
        }

        public void SetGameFactory(IGameFactory gameFactory)
        {
            this.gameFactory = gameFactory;
        }

        public void OnTimerTick()
        {
            currentGame.IncrementTimePlayed();
            UpdateTimePlayed();
        }

        public void ResetGame()
        {
            form.SetFaceButtonImage(FaceButtonImages.SMILE);
            form.ChangeCellsPanelEnable(true);
            
            UpdateMinesLeftCount(gameDifficulty.Mines);
            CreateNewGame();

            form.ResetCellViews(gameDifficulty.Width, gameDifficulty.Height);
            form.StopTimer();
            form.StartTimer();
        }
        
        public void OnGameStarted()
        {
            ConfigureFaceButton();
            ConfigureBoardHeaderAndMinesPanel();
            UpdateMinesLeftCount(gameDifficulty.Mines);
            CreateNewGame();

            form.ConfigureCellViews(gameDifficulty.Width, gameDifficulty.Height);
            form.StartTimer();
        }

        public void OnMouseDown()
        {
            if (!currentGame.IsFinished())
                form.SetFaceButtonImage(FaceButtonImages.WORRIED);
        }

        public void OnMouseUp()
        {
            if (!currentGame.IsFinished())
            {
                form.SetFaceButtonImage(FaceButtonImages.SMILE);
            }
        }

        public void OnCellRightClick(int x, int y)
        {
            currentGame.RightClickCell(x, y);
        }

        public void OnCellLeftClick(int x, int y)
        {
            currentGame.LeftClickCell(x, y);
        }

        private void ConfigureFaceButton()
        {
            form.ConfigureFaceButton(
                CellViewConfig.FaceButtonSize,
                CellViewConfig.FaceButtonSize,
                CellViewConfig.CalculateFaceButtonXPosition(gameDifficulty.Width),
                0
            );
            form.SetFaceButtonImage(FaceButtonImages.SMILE);
        }

        private void ConfigureBoardHeaderAndMinesPanel()
        {
            int panelWidth = CellViewConfig.CalculatePanelSize(gameDifficulty.Width);
            int panelHeight = CellViewConfig.CalculatePanelSize(gameDifficulty.Height);
            form.ConfigureBoardView(panelWidth, CellViewConfig.HeaderHeight, panelWidth, panelHeight);
        }

        private void UpdateMinesLeftCount(int value)
        {
            form.SetMinesLeft(FormatToThreeDigitsString(value));
        }

        private void UpdateTimePlayed()
        {
            var value = currentGame.TimePlayedInSeconds;
            if (value > 999)
            {
                value = 999;
            }
            form.SetTimePlayed(FormatToThreeDigitsString(value));
        }

        private string FormatToThreeDigitsString(int value)
        {
            string format;
            if (value >= 0)
            {
                format = "D3";
            }
            else
            {
                format = "D2";
            }
            return value.ToString(format);
        }

        private void CreateNewGame()
        {
            Player player = new Player();
            currentGame = gameFactory.CreateGame(gameDifficulty, player);
            currentGame.SetGameListener(this);
        }

        public void ShowExploitedMine(int x, int y)
        {
            form.ShowExploitedMine(x, y);
        }

        public void ShowNormalMine(int x, int y)
        {
            form.ShowNormalMine(x, y);
        }

        public void ShowMineCrossedOut(int x, int y)
        {
            form.ShowMineCrossedOut(x, y);
        }

        public void ShowEmptyCell(int x, int y)
        {
            form.ShowEmptyCell(x, y);
        }

        public void ShowNumber(int x, int y, int number)
        {
            form.ShowNumber(x, y, number);
        }

        public void ShowFlag(int x, int y, int remainingMines)
        {
            form.ShowFlag(x, y);
            UpdateMinesLeftCount(remainingMines);
        }

        public void RemoveFlag(int x, int y, int remainingMines)
        {
            form.RemoveFlag(x, y);
            UpdateMinesLeftCount(remainingMines);
        }

        public void OnLostGame()
        {
            form.ChangeCellsPanelEnable(false);
            form.StopTimer();
            form.SetFaceButtonImage(FaceButtonImages.DEAD);
        }

        public void OnGameWon()
        {
            form.ChangeCellsPanelEnable(false);
            form.StopTimer();
            form.SetFaceButtonImage(FaceButtonImages.WINNER);
        }
    }
}