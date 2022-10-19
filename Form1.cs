using BuscaminasDomain;
using BuscaminasDomain.GameRules;
using BuscaminasDomain.GameRules.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buscaminas
{
    public partial class Form1 : Form, Game.IGameListener
    {
        private Game game;
        private CellView[,] cellViews;

        private IGameFactory gameFactory;
        private GameDifficulty gameDifficulty;

        private int gameDurationInSeconds = 0;

        public Form1()
        {
            InitializeComponent();
        }

        public void SetGameDifficulty(GameDifficulty gameDifficulty)
        {
            this.gameDifficulty = gameDifficulty;
        }

        public void SetGameFactory(IGameFactory gameFactory)
        {
            this.gameFactory = gameFactory;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Images\smiley_face.png");
            pictureBox1.Size = new Size(CellViewConfig.FaceButtonSize, CellViewConfig.FaceButtonSize);
            pictureBox1.Location = new Point(CellViewConfig.CalculateFaceButtonXPosition(gameDifficulty.Width), 0);

            int panelWidth = CellViewConfig.CalculatePanelSize(gameDifficulty.Width);
            int panelHeight = CellViewConfig.CalculatePanelSize(gameDifficulty.Height);
            panelHeader.Size = new Size(panelWidth, CellViewConfig.HeaderHeight);
            panelCellsContainer.Size = new Size(panelWidth, panelHeight);

            UpdateMinesLeftCount(gameDifficulty.Mines);

            CreateNewGame();

            CreateCellViews();
            timer1.Start();
        }

        private void Cell_DelOnMouseUp(CellView cell)
        {
            if (!game.IsFinished())
            {
                pictureBox1.Image = Image.FromFile(@"Images\smiley_face.png");
            }
        }

        private void Cell_DelOnMouseDown(CellView cell)
        {
            pictureBox1.Image = Image.FromFile(@"Images\worried_face.png");
        }

        private void Cell_OnViewClick(CellView view, bool isRightClick)
        {
            if (isRightClick)
            {
                game.RightClickCell(view.X, view.Y);
            } else
            {
                game.LeftClickCell(view.X, view.Y);
            }
        }

        public void ShowExploitedMine(int x, int y)
        {
            panelCellsContainer.Enabled = false;
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

        public void ShowFlag(int x, int y, int remainingMines)
        {
            cellViews[x, y].ShowFlag();
            UpdateMinesLeftCount(remainingMines);
        }

        public void RemoveFlag(int x, int y, int remainingMines)
        {
            cellViews[x, y].RemoveFlag();
            UpdateMinesLeftCount(remainingMines);
        }

        public void OnLostGame()
        {
            timer1.Stop();
            pictureBox1.Image = Image.FromFile(@"Images\dead_face.png");
        }

        public void OnGameWon()
        {
            timer1.Stop();
            panelCellsContainer.Enabled = false;
            pictureBox1.Image = Image.FromFile(@"Images\winner_face.png");
        }

        private void CreateNewGame()
        {
            // TODO remove this hardcoded player
            Player player = new Player();
            game = gameFactory.CreateGame(gameDifficulty, player);
            game.SetGameListener(this);
        }

        private void CreateCellViews()
        {
            cellViews = new CellView[gameDifficulty.Width, gameDifficulty.Height];

            int cellSize = CellViewConfig.CellSize;

            for (int i = 0; i < gameDifficulty.Width; i++)
            {
                for (int j = 0; j < gameDifficulty.Height; j++)
                {
                    CellView cell = new CellView(i, j)
                    {
                        Size = new Size(cellSize, cellSize),
                        Location = new Point(i * cellSize, j * cellSize)
                    };
                    cell.OnCellClick += Cell_OnViewClick;
                    cell.DelOnMouseDown += Cell_DelOnMouseDown;
                    cell.DelOnMouseUp += Cell_DelOnMouseUp;

                    panelCellsContainer.Controls.Add(cell);

                    cellViews[i, j] = cell;
                }
            }
        }

        private void ResetCellViews()
        {
            for (int i = 0; i < gameDifficulty.Width; i++)
            {
                for (int j = 0; j < gameDifficulty.Height; j++)
                {
                    cellViews[i, j].Reset();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Images\smiley_face.png");
            UpdateMinesLeftCount(gameDifficulty.Mines);

            panelCellsContainer.Enabled = true;
            CreateNewGame();
            ResetCellViews();

            gameDurationInSeconds = 0;
            timer1.Start();
        }

        private void UpdateMinesLeftCount(int count)
        {
            label1.Text = FormatDigits(count);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gameDurationInSeconds++;
            label2.Text = FormatDigits(gameDurationInSeconds);
        }

        private string FormatDigits(int value)
        {
            if (value > 999)
            {
                return "999";
            }

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
    }
}
