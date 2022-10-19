namespace Buscaminas
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelGameButton = new System.Windows.Forms.Panel();
            this.panelDifficulty = new System.Windows.Forms.Panel();
            this.buttonDiffReturn = new System.Windows.Forms.Label();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonExpert = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonIntermediate = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonEasy = new System.Windows.Forms.RadioButton();
            this.panelMultiplayer = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelGameButton.SuspendLayout();
            this.panelDifficulty.SuspendLayout();
            this.panelMultiplayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MINE-SWEEPER", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscaminas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("DS-Digital", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(303, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Un jugador";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("DS-Digital", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(3, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(303, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "Multijugador";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Buscaminas.Properties.Resources.mine_normal;
            this.pictureBox1.Location = new System.Drawing.Point(370, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 66);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panelGameButton
            // 
            this.panelGameButton.Controls.Add(this.button1);
            this.panelGameButton.Controls.Add(this.button2);
            this.panelGameButton.Location = new System.Drawing.Point(241, 340);
            this.panelGameButton.Name = "panelGameButton";
            this.panelGameButton.Size = new System.Drawing.Size(311, 98);
            this.panelGameButton.TabIndex = 5;
            // 
            // panelDifficulty
            // 
            this.panelDifficulty.Controls.Add(this.buttonDiffReturn);
            this.panelDifficulty.Controls.Add(this.buttonStartGame);
            this.panelDifficulty.Controls.Add(this.label4);
            this.panelDifficulty.Controls.Add(this.radioButtonExpert);
            this.panelDifficulty.Controls.Add(this.label3);
            this.panelDifficulty.Controls.Add(this.radioButtonIntermediate);
            this.panelDifficulty.Controls.Add(this.label2);
            this.panelDifficulty.Controls.Add(this.radioButtonEasy);
            this.panelDifficulty.Location = new System.Drawing.Point(305, 150);
            this.panelDifficulty.Name = "panelDifficulty";
            this.panelDifficulty.Size = new System.Drawing.Size(198, 298);
            this.panelDifficulty.TabIndex = 6;
            this.panelDifficulty.Visible = false;
            // 
            // buttonDiffReturn
            // 
            this.buttonDiffReturn.Font = new System.Drawing.Font("DS-Digital", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDiffReturn.Location = new System.Drawing.Point(-1, 264);
            this.buttonDiffReturn.Name = "buttonDiffReturn";
            this.buttonDiffReturn.Size = new System.Drawing.Size(199, 34);
            this.buttonDiffReturn.TabIndex = 8;
            this.buttonDiffReturn.Text = "Volver";
            this.buttonDiffReturn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonDiffReturn.Click += new System.EventHandler(this.buttonDiffReturn_Click);
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Font = new System.Drawing.Font("DS-Digital", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartGame.Location = new System.Drawing.Point(0, 222);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(198, 41);
            this.buttonStartGame.TabIndex = 7;
            this.buttonStartGame.Text = "Comenzar";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 38);
            this.label4.TabIndex = 6;
            this.label4.Text = "30 x 16 casillas y 99 minas";
            // 
            // radioButtonExpert
            // 
            this.radioButtonExpert.AutoSize = true;
            this.radioButtonExpert.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonExpert.Location = new System.Drawing.Point(12, 149);
            this.radioButtonExpert.Name = "radioButtonExpert";
            this.radioButtonExpert.Size = new System.Drawing.Size(107, 29);
            this.radioButtonExpert.TabIndex = 5;
            this.radioButtonExpert.Text = "Experto";
            this.radioButtonExpert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonExpert.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 35);
            this.label3.TabIndex = 4;
            this.label3.Text = "16 x 16 casillas y 40 minas";
            // 
            // radioButtonIntermediate
            // 
            this.radioButtonIntermediate.AutoSize = true;
            this.radioButtonIntermediate.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonIntermediate.Location = new System.Drawing.Point(12, 76);
            this.radioButtonIntermediate.Name = "radioButtonIntermediate";
            this.radioButtonIntermediate.Size = new System.Drawing.Size(140, 29);
            this.radioButtonIntermediate.TabIndex = 3;
            this.radioButtonIntermediate.Text = "Intermedio";
            this.radioButtonIntermediate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonIntermediate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "8 x 8 casillas y 10 minas";
            // 
            // radioButtonEasy
            // 
            this.radioButtonEasy.AutoSize = true;
            this.radioButtonEasy.Checked = true;
            this.radioButtonEasy.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonEasy.Location = new System.Drawing.Point(12, 13);
            this.radioButtonEasy.Name = "radioButtonEasy";
            this.radioButtonEasy.Size = new System.Drawing.Size(162, 29);
            this.radioButtonEasy.TabIndex = 0;
            this.radioButtonEasy.TabStop = true;
            this.radioButtonEasy.Text = "Principiante";
            this.radioButtonEasy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonEasy.UseVisualStyleBackColor = true;
            // 
            // panelMultiplayer
            // 
            this.panelMultiplayer.Controls.Add(this.button4);
            this.panelMultiplayer.Controls.Add(this.label5);
            this.panelMultiplayer.Controls.Add(this.listBox1);
            this.panelMultiplayer.Controls.Add(this.button3);
            this.panelMultiplayer.Location = new System.Drawing.Point(257, 147);
            this.panelMultiplayer.Name = "panelMultiplayer";
            this.panelMultiplayer.Size = new System.Drawing.Size(279, 298);
            this.panelMultiplayer.TabIndex = 7;
            this.panelMultiplayer.Visible = false;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("DS-Digital", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(5, 223);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(271, 41);
            this.button3.TabIndex = 9;
            this.button3.Text = "Nueva partida";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(5, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(271, 173);
            this.listBox1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("DS-Digital", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(271, 34);
            this.label5.TabIndex = 9;
            this.label5.Text = "Volver";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("DS-Digital", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(5, 178);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(271, 41);
            this.button4.TabIndex = 11;
            this.button4.Text = "Unirme";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMultiplayer);
            this.Controls.Add(this.panelDifficulty);
            this.Controls.Add(this.panelGameButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenuForm";
            this.Text = "Buscaminas";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelGameButton.ResumeLayout(false);
            this.panelDifficulty.ResumeLayout(false);
            this.panelDifficulty.PerformLayout();
            this.panelMultiplayer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelGameButton;
        private System.Windows.Forms.Panel panelDifficulty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonExpert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonIntermediate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonEasy;
        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Label buttonDiffReturn;
        private System.Windows.Forms.Panel panelMultiplayer;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button3;
    }
}