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

        private bool creatingSingleGame = false;

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
            // cargar los rooms o las partidas del usuario
            if (radioButtonOpenRooms.Checked)
            {
                presenter.ShowMultiplayerOpenRooms();
            }
            else if (radioButtonMpgInProgressGames.Checked)
            {
                presenter.ShowMultiplayerGamesInProgess();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelGameButton.Visible = false;
            panelSinglePlayerLoadNew.Visible = true;
            panelMultiplayer.Visible = false;
            panelDifficulty.Visible = false;

            presenter.ShowSinglePlayerGames();
        }

        private void buttonDiffReturn_Click(object sender, EventArgs e)
        {
            panelGameButton.Visible = false;
            panelSinglePlayerLoadNew.Visible = creatingSingleGame;
            panelDifficulty.Visible = false;
            panelMultiplayer.Visible = !creatingSingleGame;
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

            if (creatingSingleGame)
            {
                presenter.StartNewSinglePlayerGame(selectedCheckbox);
            } else
            {
                presenter.StartNewMultiplayerGame(selectedCheckbox);
            }
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
            creatingSingleGame = false;

            panelGameButton.Visible = false;
            panelSinglePlayerLoadNew.Visible = false;
            panelDifficulty.Visible = true;
            panelMultiplayer.Visible = false;
        }

        private void btnSpgNewGame_Click(object sender, EventArgs e)
        {
            creatingSingleGame = true;

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

        private void refrescarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (radioButtonOpenRooms.Checked)
            {
                presenter.ShowMultiplayerOpenRooms();
            }
            else if (radioButtonMpgInProgressGames.Checked)
            {
                presenter.ShowMultiplayerGamesInProgess();
            }
        }

        private void radioButtonOpenRooms_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOpenRooms.Checked)
            {
                presenter.ShowMultiplayerOpenRooms();
            }
        }

        private void radioButtonMpgInProgressGames_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMpgInProgressGames.Checked)
            {
                presenter.ShowMultiplayerGamesInProgess();
            }
        }

        public void ShowMultiPlayerRooms(List<InProgressGameViewItem> items)
        {
            listBoxMpgRooms.Items.Clear();
            listBoxMpgRooms.Items.AddRange(items.ToArray());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InProgressGameViewItem selectedGame = (InProgressGameViewItem) listBoxMpgRooms.SelectedItem;
            if (radioButtonOpenRooms.Checked)
            {
                presenter.JoinMultiplayerGame(selectedGame);
            } else
            {
                presenter.LoadMultiplayerGame(selectedGame);
            }
        }

        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            GameHistoryForm form = new GameHistoryForm();
            form.Show();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            presenter.Logout();
        }

        public void ChangeUserMenuVisibility(bool isVisible)
        {
            buttonStatistics.Visible = isVisible;
            buttonLogout.Visible = isVisible;
            labelUserName.Visible = isVisible;
        }
    }
}
