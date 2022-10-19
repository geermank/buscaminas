using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuscaminasDomain;

namespace Buscaminas
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelGameButton.Visible = false;
            panelMultiplayer.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelGameButton.Visible = false;
            panelDifficulty.Visible = true;
        }

        private void buttonDiffReturn_Click(object sender, EventArgs e)
        {
            panelGameButton.Visible = true;
            panelDifficulty.Visible = false;
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            GameDifficulty gameDifficulty;
            if (radioButtonEasy.Checked)
            {
                gameDifficulty = GameDifficultyFactory.CreateEasyGame();
            } else if (radioButtonIntermediate.Checked)
            {
                gameDifficulty = GameDifficultyFactory.CreateIntermediateGame();
            } else
            {
                gameDifficulty = GameDifficultyFactory.CreateHardGame();
            }

            Form1 gameForm = new Form1();
            gameForm.SetGameDifficulty(gameDifficulty);
            gameForm.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            panelGameButton.Visible = true;
            panelMultiplayer.Visible = false;
        }
    }
}
