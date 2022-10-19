using System;
using System.Drawing;
using System.Windows.Forms;

namespace Buscaminas
{
    public partial class CellView : UserControl
    {
        public delegate void DelCellViewClick(CellView cell, bool isRightClick);
        public delegate void DelCellViewMouseDown(CellView cell);
        public delegate void DelCellViewMouseUp(CellView cell);

        public event DelCellViewClick OnCellClick;
        public event DelCellViewMouseDown DelOnMouseDown;
        public event DelCellViewMouseUp DelOnMouseUp;

        private int x;
        private int y;

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public CellView(int x, int y)
        {
            InitializeComponent();
            this.x = x;
            this.y = y;
            this.pictureBox1.Image = Image.FromFile(@"Images\cell_uncovered.png");
        }

        public void ShowFlag()
        {
            this.pictureBox1.Image = Image.FromFile(@"Images\flag_cell.png");
        }

        public void RemoveFlag()
        {
            this.pictureBox1.Image = Image.FromFile(@"Images\cell_uncovered.png");
        }

        public void ShowNumber(int number)
        {
            this.pictureBox1.Image = Image.FromFile(@"Images\number_cell_bg.png");
            labelNumber.Text = number.ToString();
            labelNumber.ForeColor = NumberColorMapper.getInstance().MapNumberToColor(number);
        }

        public void ShowEmptyCell()
        {
            this.pictureBox1.Image = Image.FromFile(@"Images\number_cell_bg.png");
            this.Enabled = false;
        }

        public void ShowExploitedMine()
        {
            this.pictureBox1.Image = Image.FromFile(@"Images\mine_selected.png");
        }

        public void ShowNormalMine()
        {
            this.pictureBox1.Image = Image.FromFile(@"Images\mine_normal.png");
        }

        public void ShowCrossedOutMine()
        {
            this.pictureBox1.Image = Image.FromFile(@"Images\mine_crossed_out.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEvent = (MouseEventArgs) e;
            OnCellClick(this, mouseEvent.Button == MouseButtons.Right);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            DelOnMouseDown(this);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            DelOnMouseUp(this);
        }
    }
}
