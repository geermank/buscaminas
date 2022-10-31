using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Buscaminas.MainMenu;
using BuscaminasDomain;
using BuscaminasDomain.GameRules.Factories;

namespace Buscaminas
{
    public partial class MainMenuForm : Form, IMainMenuForm
    {
        private MainMenuPresenter presenter;

        public MainMenuForm()
        {
            InitializeComponent();
            presenter = new MainMenuPresenter(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelGameButton.Visible = false;
            panelSinglePlayerLoadNew.Visible = false;
            panelMultiplayer.Visible = true;
            panelDifficulty.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelGameButton.Visible = false;
            panelSinglePlayerLoadNew.Visible = true;
            panelMultiplayer.Visible = false;
            panelDifficulty.Visible = false;
        }

        private void buttonDiffReturn_Click(object sender, EventArgs e)
        {
            panelGameButton.Visible = false;
            panelSinglePlayerLoadNew.Visible = true;
            panelDifficulty.Visible = false;
            panelMultiplayer.Visible = false;
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            GameCheckBoxDifficulty selectedCheckbox;
            if (radioButtonEasy.Checked)
            {
                selectedCheckbox = GameCheckBoxDifficulty.EASY;
            }
            else if (radioButtonIntermediate.Checked)
            {
                selectedCheckbox = GameCheckBoxDifficulty.INTERMEDIATE;
            }
            else
            {
                selectedCheckbox = GameCheckBoxDifficulty.HARD;
            }
            presenter.StartSingleGame(selectedCheckbox);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            panelGameButton.Visible = true;
            panelMultiplayer.Visible = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (RegisterForm form = new RegisterForm())
            {
                HandleRegisterLoginResult(form.ShowDialog());
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {   
            using(RegisterForm form = new RegisterForm())
            {
                form.SetAsLogin();
                HandleRegisterLoginResult(form.ShowDialog());
            }
        }

        private void HandleRegisterLoginResult(DialogResult resultCode)
        {
            if (resultCode == DialogResult.OK)
            {
                presenter.OnUserLoggedInOrRegistered();
            }
        }

        public void ChangeUserLoggedButtonEnable(bool isEnable)
        {
            button2.Enabled = isEnable;
            btnSpgContinue.Enabled = isEnable;
        }

        public void SetCurrentUserName(string userName)
        {
            labelUserName.Visible = true;
            labelUserName.Text = "Usuario actual: " + userName;
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            presenter.OnStartForm();
        }

        public void LaunchGame(IGameFactory gameFactory, GameDifficulty difficulty)
        {
            Form1 gameForm = new Form1();
            gameForm.SetGameDifficulty(difficulty);
            gameForm.SetGameFactory(gameFactory);
            gameForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            presenter.StartMultiplayerGame();
        }

        private void btnSpgNewGame_Click(object sender, EventArgs e)
        {
            panelGameButton.Visible = false;
            panelSinglePlayerLoadNew.Visible = false;
            panelDifficulty.Visible = true;
            panelMultiplayer.Visible = false;
        }

        private void btnReturnSpgMenu_Click(object sender, EventArgs e)
        {
            panelGameButton.Visible = true;
            panelSinglePlayerLoadNew.Visible = false;
            panelDifficulty.Visible = false;
            panelMultiplayer.Visible = false;
        }

        public void ShowSinglePlayerInProgressGames(List<InProgressGameViewItem> items)
        {
            listBoxInProgressSpg.Items.Clear();
            foreach(InProgressGameViewItem item in items)
            {
                listBoxInProgressSpg.Items.Add(item);
            }
        }

        private void btnSpgContinue_Click(object sender, EventArgs e)
        {
            InProgressGameViewItem selectedGame = (InProgressGameViewItem) listBoxInProgressSpg.SelectedItem;
            presenter.ContinueSinglePlayerGame(selectedGame);
        }

        private void refrescarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.RefreshSinglePlayerGames();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
