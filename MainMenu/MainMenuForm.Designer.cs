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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelGameButton = new System.Windows.Forms.Panel();
            this.panelDifficulty = new System.Windows.Forms.Panel();
            this.buttonDiffReturn = new System.Windows.Forms.Label();
            this.buttonStartNewSpg = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonExpert = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonIntermediate = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonEasy = new System.Windows.Forms.RadioButton();
            this.panelMultiplayer = new System.Windows.Forms.Panel();
            this.contextMenuStripMpgRefresh = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refrescarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.radioButtonOpenRooms = new System.Windows.Forms.RadioButton();
            this.radioButtonMpgInProgressGames = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxMpgRooms = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.panelSinglePlayerLoadNew = new System.Windows.Forms.Panel();
            this.contextMenuStripRefrescarSPG = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refrescarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReturnSpgMenu = new System.Windows.Forms.Label();
            this.btnSpgNewGame = new System.Windows.Forms.Button();
            this.btnSpgContinue = new System.Windows.Forms.Button();
            this.listBoxInProgressSpg = new System.Windows.Forms.ListBox();
            this.buttonStatistics = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.panelGameButton.SuspendLayout();
            this.panelDifficulty.SuspendLayout();
            this.panelMultiplayer.SuspendLayout();
            this.contextMenuStripMpgRefresh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelSinglePlayerLoadNew.SuspendLayout();
            this.contextMenuStripRefrescarSPG.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MINE-SWEEPER", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(305, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 44);
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
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("DS-Digital", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(3, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(303, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "Multijugador";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelGameButton
            // 
            this.panelGameButton.Controls.Add(this.button1);
            this.panelGameButton.Controls.Add(this.button2);
            this.panelGameButton.Location = new System.Drawing.Point(242, 172);
            this.panelGameButton.Name = "panelGameButton";
            this.panelGameButton.Size = new System.Drawing.Size(311, 98);
            this.panelGameButton.TabIndex = 5;
            // 
            // panelDifficulty
            // 
            this.panelDifficulty.Controls.Add(this.buttonDiffReturn);
            this.panelDifficulty.Controls.Add(this.buttonStartNewSpg);
            this.panelDifficulty.Controls.Add(this.label4);
            this.panelDifficulty.Controls.Add(this.radioButtonExpert);
            this.panelDifficulty.Controls.Add(this.label3);
            this.panelDifficulty.Controls.Add(this.radioButtonIntermediate);
            this.panelDifficulty.Controls.Add(this.label2);
            this.panelDifficulty.Controls.Add(this.radioButtonEasy);
            this.panelDifficulty.Location = new System.Drawing.Point(307, 144);
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
            // buttonStartNewSpg
            // 
            this.buttonStartNewSpg.Font = new System.Drawing.Font("DS-Digital", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartNewSpg.Location = new System.Drawing.Point(0, 222);
            this.buttonStartNewSpg.Name = "buttonStartNewSpg";
            this.buttonStartNewSpg.Size = new System.Drawing.Size(198, 41);
            this.buttonStartNewSpg.TabIndex = 7;
            this.buttonStartNewSpg.Text = "Comenzar";
            this.buttonStartNewSpg.UseVisualStyleBackColor = true;
            this.buttonStartNewSpg.Click += new System.EventHandler(this.buttonStartGame_Click);
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
            this.panelMultiplayer.ContextMenuStrip = this.contextMenuStripMpgRefresh;
            this.panelMultiplayer.Controls.Add(this.radioButtonOpenRooms);
            this.panelMultiplayer.Controls.Add(this.radioButtonMpgInProgressGames);
            this.panelMultiplayer.Controls.Add(this.button4);
            this.panelMultiplayer.Controls.Add(this.label5);
            this.panelMultiplayer.Controls.Add(this.listBoxMpgRooms);
            this.panelMultiplayer.Controls.Add(this.button3);
            this.panelMultiplayer.Location = new System.Drawing.Point(258, 147);
            this.panelMultiplayer.Name = "panelMultiplayer";
            this.panelMultiplayer.Size = new System.Drawing.Size(279, 298);
            this.panelMultiplayer.TabIndex = 7;
            this.panelMultiplayer.Visible = false;
            // 
            // contextMenuStripMpgRefresh
            // 
            this.contextMenuStripMpgRefresh.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refrescarToolStripMenuItem1});
            this.contextMenuStripMpgRefresh.Name = "contextMenuStripMpgRefresh";
            this.contextMenuStripMpgRefresh.Size = new System.Drawing.Size(123, 26);
            // 
            // refrescarToolStripMenuItem1
            // 
            this.refrescarToolStripMenuItem1.Name = "refrescarToolStripMenuItem1";
            this.refrescarToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.refrescarToolStripMenuItem1.Text = "Refrescar";
            this.refrescarToolStripMenuItem1.Click += new System.EventHandler(this.refrescarToolStripMenuItem1_Click);
            // 
            // radioButtonOpenRooms
            // 
            this.radioButtonOpenRooms.AutoSize = true;
            this.radioButtonOpenRooms.Checked = true;
            this.radioButtonOpenRooms.Location = new System.Drawing.Point(52, 7);
            this.radioButtonOpenRooms.Name = "radioButtonOpenRooms";
            this.radioButtonOpenRooms.Size = new System.Drawing.Size(51, 17);
            this.radioButtonOpenRooms.TabIndex = 13;
            this.radioButtonOpenRooms.TabStop = true;
            this.radioButtonOpenRooms.Text = "Salas";
            this.radioButtonOpenRooms.UseVisualStyleBackColor = true;
            this.radioButtonOpenRooms.CheckedChanged += new System.EventHandler(this.radioButtonOpenRooms_CheckedChanged);
            // 
            // radioButtonMpgInProgressGames
            // 
            this.radioButtonMpgInProgressGames.AutoSize = true;
            this.radioButtonMpgInProgressGames.Location = new System.Drawing.Point(166, 7);
            this.radioButtonMpgInProgressGames.Name = "radioButtonMpgInProgressGames";
            this.radioButtonMpgInProgressGames.Size = new System.Drawing.Size(81, 17);
            this.radioButtonMpgInProgressGames.TabIndex = 12;
            this.radioButtonMpgInProgressGames.Text = "Mis partidas";
            this.radioButtonMpgInProgressGames.UseVisualStyleBackColor = true;
            this.radioButtonMpgInProgressGames.CheckedChanged += new System.EventHandler(this.radioButtonMpgInProgressGames_CheckedChanged);
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
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            // listBoxMpgRooms
            // 
            this.listBoxMpgRooms.FormattingEnabled = true;
            this.listBoxMpgRooms.Location = new System.Drawing.Point(5, 30);
            this.listBoxMpgRooms.Name = "listBoxMpgRooms";
            this.listBoxMpgRooms.Size = new System.Drawing.Size(271, 147);
            this.listBoxMpgRooms.TabIndex = 10;
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
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(679, 411);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(101, 34);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Iniciar sesión";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(679, 375);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(101, 34);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "Registrarse";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
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
            // labelUserName
            // 
            this.labelUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(3, 377);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(44, 13);
            this.labelUserName.TabIndex = 10;
            this.labelUserName.Text = "German";
            this.labelUserName.Visible = false;
            // 
            // panelSinglePlayerLoadNew
            // 
            this.panelSinglePlayerLoadNew.ContextMenuStrip = this.contextMenuStripRefrescarSPG;
            this.panelSinglePlayerLoadNew.Controls.Add(this.btnReturnSpgMenu);
            this.panelSinglePlayerLoadNew.Controls.Add(this.btnSpgNewGame);
            this.panelSinglePlayerLoadNew.Controls.Add(this.btnSpgContinue);
            this.panelSinglePlayerLoadNew.Controls.Add(this.listBoxInProgressSpg);
            this.panelSinglePlayerLoadNew.Location = new System.Drawing.Point(272, 168);
            this.panelSinglePlayerLoadNew.Name = "panelSinglePlayerLoadNew";
            this.panelSinglePlayerLoadNew.Size = new System.Drawing.Size(250, 288);
            this.panelSinglePlayerLoadNew.TabIndex = 11;
            this.panelSinglePlayerLoadNew.Visible = false;
            // 
            // contextMenuStripRefrescarSPG
            // 
            this.contextMenuStripRefrescarSPG.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refrescarToolStripMenuItem});
            this.contextMenuStripRefrescarSPG.Name = "contextMenuStripRefrescarSPG";
            this.contextMenuStripRefrescarSPG.Size = new System.Drawing.Size(123, 26);
            // 
            // refrescarToolStripMenuItem
            // 
            this.refrescarToolStripMenuItem.Name = "refrescarToolStripMenuItem";
            this.refrescarToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.refrescarToolStripMenuItem.Text = "Refrescar";
            this.refrescarToolStripMenuItem.Click += new System.EventHandler(this.refrescarToolStripMenuItem_Click);
            // 
            // btnReturnSpgMenu
            // 
            this.btnReturnSpgMenu.Font = new System.Drawing.Font("DS-Digital", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnSpgMenu.Location = new System.Drawing.Point(12, 242);
            this.btnReturnSpgMenu.Name = "btnReturnSpgMenu";
            this.btnReturnSpgMenu.Size = new System.Drawing.Size(228, 34);
            this.btnReturnSpgMenu.TabIndex = 12;
            this.btnReturnSpgMenu.Text = "Volver";
            this.btnReturnSpgMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnReturnSpgMenu.Click += new System.EventHandler(this.btnReturnSpgMenu_Click);
            // 
            // btnSpgNewGame
            // 
            this.btnSpgNewGame.Font = new System.Drawing.Font("DS-Digital", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpgNewGame.Location = new System.Drawing.Point(12, 198);
            this.btnSpgNewGame.Name = "btnSpgNewGame";
            this.btnSpgNewGame.Size = new System.Drawing.Size(228, 41);
            this.btnSpgNewGame.TabIndex = 13;
            this.btnSpgNewGame.Text = "Nueva partida";
            this.btnSpgNewGame.UseVisualStyleBackColor = true;
            this.btnSpgNewGame.Click += new System.EventHandler(this.btnSpgNewGame_Click);
            // 
            // btnSpgContinue
            // 
            this.btnSpgContinue.Enabled = false;
            this.btnSpgContinue.Font = new System.Drawing.Font("DS-Digital", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpgContinue.Location = new System.Drawing.Point(12, 151);
            this.btnSpgContinue.Name = "btnSpgContinue";
            this.btnSpgContinue.Size = new System.Drawing.Size(228, 41);
            this.btnSpgContinue.TabIndex = 12;
            this.btnSpgContinue.Text = "Continuar";
            this.btnSpgContinue.UseVisualStyleBackColor = true;
            this.btnSpgContinue.Click += new System.EventHandler(this.btnSpgContinue_Click);
            // 
            // listBoxInProgressSpg
            // 
            this.listBoxInProgressSpg.ContextMenuStrip = this.contextMenuStripRefrescarSPG;
            this.listBoxInProgressSpg.FormattingEnabled = true;
            this.listBoxInProgressSpg.Location = new System.Drawing.Point(12, 11);
            this.listBoxInProgressSpg.Name = "listBoxInProgressSpg";
            this.listBoxInProgressSpg.Size = new System.Drawing.Size(228, 134);
            this.listBoxInProgressSpg.TabIndex = 0;
            // 
            // buttonStatistics
            // 
            this.buttonStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStatistics.Location = new System.Drawing.Point(3, 392);
            this.buttonStatistics.Name = "buttonStatistics";
            this.buttonStatistics.Size = new System.Drawing.Size(77, 25);
            this.buttonStatistics.TabIndex = 12;
            this.buttonStatistics.Text = "Estadísticas";
            this.buttonStatistics.UseVisualStyleBackColor = true;
            this.buttonStatistics.Visible = false;
            this.buttonStatistics.Click += new System.EventHandler(this.buttonStatistics_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLogout.BackColor = System.Drawing.SystemColors.Control;
            this.buttonLogout.ForeColor = System.Drawing.Color.Red;
            this.buttonLogout.Location = new System.Drawing.Point(3, 420);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(77, 25);
            this.buttonLogout.TabIndex = 13;
            this.buttonLogout.Text = "Cerrar sesión";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Visible = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(783, 450);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonStatistics);
            this.Controls.Add(this.panelSinglePlayerLoadNew);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.panelMultiplayer);
            this.Controls.Add(this.panelDifficulty);
            this.Controls.Add(this.panelGameButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscaminas";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.panelGameButton.ResumeLayout(false);
            this.panelDifficulty.ResumeLayout(false);
            this.panelDifficulty.PerformLayout();
            this.panelMultiplayer.ResumeLayout(false);
            this.panelMultiplayer.PerformLayout();
            this.contextMenuStripMpgRefresh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelSinglePlayerLoadNew.ResumeLayout(false);
            this.contextMenuStripRefrescarSPG.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonStartNewSpg;
        private System.Windows.Forms.Label buttonDiffReturn;
        private System.Windows.Forms.Panel panelMultiplayer;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxMpgRooms;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Panel panelSinglePlayerLoadNew;
        private System.Windows.Forms.Button btnSpgNewGame;
        private System.Windows.Forms.Button btnSpgContinue;
        private System.Windows.Forms.ListBox listBoxInProgressSpg;
        private System.Windows.Forms.Label btnReturnSpgMenu;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRefrescarSPG;
        private System.Windows.Forms.ToolStripMenuItem refrescarToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButtonOpenRooms;
        private System.Windows.Forms.RadioButton radioButtonMpgInProgressGames;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMpgRefresh;
        private System.Windows.Forms.ToolStripMenuItem refrescarToolStripMenuItem1;
        private System.Windows.Forms.Button buttonStatistics;
        private System.Windows.Forms.Button buttonLogout;
    }
}