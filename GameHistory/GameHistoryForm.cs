using Buscaminas.GameHistory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Buscaminas.GameHistory.GameHistoryPresenter;

namespace Buscaminas
{
    public partial class GameHistoryForm : Form, IGameHistoryForm
    {
        private GameHistoryPresenter presenter;

        public GameHistoryForm()
        {
            InitializeComponent();
            presenter = new GameHistoryPresenter(this);
        }

        public void ShowGamesHistory(List<GameHistoryItem> games)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(games.ToArray());
        }

        public void ShowGamesLostCount(string labelValue)
        {
            labelLostGamesCount.Text = labelValue;
        }

        public void ShowGamesTieCount(string labelValue)
        {
            labelTieGamesCount.Text = labelValue;
        }

        public void ShowGamesWonCount(string labelValue)
        {
            labelWinGamesCount.Text = labelValue;
        }

        public void ShowTotalTimePlayed(string labelValue)
        {
            labelTimePlayedValue.Text = labelValue;
        }

        public void ShowWinRate(string labelValue)
        {
            labelWinRateValue.Text = labelValue;
        }

        private void GameHistoryForm_Load(object sender, EventArgs e)
        {
            presenter.OnFormStarted();
        }
    }
}
