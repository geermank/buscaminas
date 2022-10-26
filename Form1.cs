using BuscaminasDomain;
using BuscaminasDomain.GameRules.Factories;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Buscaminas
{
    public partial class Form1 : Form, IGameForm
    {
        private CellView[,] cellViews;

        private GameFormPresenter presenter;

        public Form1()
        {
            InitializeComponent();
            presenter = new GameFormPresenter(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            presenter.OnGameStarted();
        }

        public void SetGameDifficulty(GameDifficulty gameDifficulty)
        {
            presenter.SetGameDifficulty(gameDifficulty);
        }

        public void SetGameFactory(IGameFactory gameFactory)
        {
            presenter.SetGameFactory(gameFactory);
        }

        private void Cell_DelOnMouseUp(CellView cell)
        {
            presenter.OnMouseUp();
        }

        private void Cell_DelOnMouseDown(CellView cell)
        {
            presenter.OnMouseDown();
        }

        private void Cell_OnViewClick(CellView view, bool isRightClick)
        {
            if (isRightClick)
            {
                presenter.OnCellRightClick(view.X, view.Y);
            } else
            {
                presenter.OnCellLeftClick(view.X, view.Y);
            }
        }

        public void ShowExploitedMine(int x, int y)
        {
            cellViews[x, y].ShowExploitedMine();
        }

        public void ShowNormalMine(int x, int y)
        {
            cellViews[x, y].ShowNormalMine();
        }

        public void ShowMineCrossedOut(int x, int y)
        {
            cellViews[x, y].ShowCrossedOutMine();
        }

        public void ShowEmptyCell(int x, int y)
        {
            cellViews[x, y].ShowEmptyCell();
        }

        public void ShowNumber(int x, int y, int number)
        {
            cellViews[x, y].ShowNumber(number);
        }

        public void ShowFlag(int x, int y)
        {
            cellViews[x, y].ShowFlag();
        }

        public void RemoveFlag(int x, int y)
        {
            cellViews[x, y].RemoveFlag();
        }

        public void ResetCellViews(int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    cellViews[i, j].Reset();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            presenter.ResetGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            presenter.OnTimerTick();
        }

        public void ConfigureFaceButton(int width, int height, int x, int y)
        {
            pictureBox1.Size = new Size(width, height);
            pictureBox1.Location = new Point(x, y);
        }

        public void SetFaceButtonImage(string path)
        {
            pictureBox1.Image = Image.FromFile(path);
        }

        public void ConfigureBoardView(int headerWidth, int headerHeight, int panelWidth, int panelHeight)
        {
            panelHeader.Size = new Size(headerWidth, headerHeight);
            panelCellsContainer.Size = new Size(panelWidth, panelHeight);  
        }

        public void ConfigureCellViews(int width, int height, int cellSize)
        {
            cellViews = new CellView[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    CellView cell = new CellView(x, y)
                    {
                        Size = new Size(cellSize, cellSize),
                        Location = new Point(x * cellSize, y * cellSize)
                    };
                    cell.OnCellClick += Cell_OnViewClick;
                    cell.DelOnMouseDown += Cell_DelOnMouseDown;
                    cell.DelOnMouseUp += Cell_DelOnMouseUp;

                    panelCellsContainer.Controls.Add(cell);

                    cellViews[x, y] = cell;
                }
            }
        }

        public void SetMinesLeft(string minesLeft)
        {
            label1.Text = minesLeft;
        }

        public void StartTimer()
        {
            timer1.Start();
        }

        public void StopTimer()
        {
            timer1.Stop();
        }

        public void ChangeCellsPanelEnable(bool isEnabled)
        {
            panelCellsContainer.Enabled = isEnabled;
        }

        public void SetTimePlayed(string timePlayedInSeconds)
        {
            label2.Text = timePlayedInSeconds;
        }

        public void ShowPlayers(string player1, string player2)
        {
            labelPlayer1.Visible = true;
            labelPlayer1.Text = player1;

            labelPlayer2.Visible = true;
            labelPlayer2.Text = player2;
        }

        public void ShowCurrentTurnPlayer(string player)
        {
            labelTurnOwner.Visible = true;
            labelTurnOwner.Text = player;
        }
    }
}
