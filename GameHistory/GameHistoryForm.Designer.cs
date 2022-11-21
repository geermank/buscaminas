namespace Buscaminas
{
    partial class GameHistoryForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.labelWinGamesCount = new System.Windows.Forms.Label();
            this.labelTieGamesCount = new System.Windows.Forms.Label();
            this.labelLostGamesCount = new System.Windows.Forms.Label();
            this.labelWinRate = new System.Windows.Forms.Label();
            this.labelWinRateValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTimePlayedValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 104);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(776, 329);
            this.listBox1.TabIndex = 0;
            // 
            // labelWinGamesCount
            // 
            this.labelWinGamesCount.AutoSize = true;
            this.labelWinGamesCount.Font = new System.Drawing.Font("MINE-SWEEPER", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWinGamesCount.Location = new System.Drawing.Point(532, 20);
            this.labelWinGamesCount.Name = "labelWinGamesCount";
            this.labelWinGamesCount.Size = new System.Drawing.Size(192, 15);
            this.labelWinGamesCount.TabIndex = 1;
            this.labelWinGamesCount.Text = "Partidas ganadas:";
            // 
            // labelTieGamesCount
            // 
            this.labelTieGamesCount.AutoSize = true;
            this.labelTieGamesCount.Font = new System.Drawing.Font("MINE-SWEEPER", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTieGamesCount.Location = new System.Drawing.Point(532, 47);
            this.labelTieGamesCount.Name = "labelTieGamesCount";
            this.labelTieGamesCount.Size = new System.Drawing.Size(215, 15);
            this.labelTieGamesCount.TabIndex = 2;
            this.labelTieGamesCount.Text = "Partidas empatadas:";
            // 
            // labelLostGamesCount
            // 
            this.labelLostGamesCount.AutoSize = true;
            this.labelLostGamesCount.Font = new System.Drawing.Font("MINE-SWEEPER", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLostGamesCount.Location = new System.Drawing.Point(532, 75);
            this.labelLostGamesCount.Name = "labelLostGamesCount";
            this.labelLostGamesCount.Size = new System.Drawing.Size(201, 15);
            this.labelLostGamesCount.TabIndex = 3;
            this.labelLostGamesCount.Text = "Partidas perdidas:";
            // 
            // labelWinRate
            // 
            this.labelWinRate.AutoSize = true;
            this.labelWinRate.Font = new System.Drawing.Font("MINE-SWEEPER", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWinRate.Location = new System.Drawing.Point(12, 39);
            this.labelWinRate.Name = "labelWinRate";
            this.labelWinRate.Size = new System.Drawing.Size(237, 15);
            this.labelWinRate.TabIndex = 4;
            this.labelWinRate.Text = "Promedio de victorias";
            // 
            // labelWinRateValue
            // 
            this.labelWinRateValue.AutoSize = true;
            this.labelWinRateValue.Font = new System.Drawing.Font("MINE-SWEEPER", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWinRateValue.Location = new System.Drawing.Point(81, 59);
            this.labelWinRateValue.Name = "labelWinRateValue";
            this.labelWinRateValue.Size = new System.Drawing.Size(75, 15);
            this.labelWinRateValue.TabIndex = 5;
            this.labelWinRateValue.Text = "40.50%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MINE-SWEEPER", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(313, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tiempo jugado";
            // 
            // labelTimePlayedValue
            // 
            this.labelTimePlayedValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTimePlayedValue.AutoSize = true;
            this.labelTimePlayedValue.Font = new System.Drawing.Font("MINE-SWEEPER", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimePlayedValue.Location = new System.Drawing.Point(319, 59);
            this.labelTimePlayedValue.Name = "labelTimePlayedValue";
            this.labelTimePlayedValue.Size = new System.Drawing.Size(142, 15);
            this.labelTimePlayedValue.TabIndex = 7;
            this.labelTimePlayedValue.Text = "100 segundos";
            this.labelTimePlayedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTimePlayedValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelWinRateValue);
            this.Controls.Add(this.labelWinRate);
            this.Controls.Add(this.labelLostGamesCount);
            this.Controls.Add(this.labelTieGamesCount);
            this.Controls.Add(this.labelWinGamesCount);
            this.Controls.Add(this.listBox1);
            this.Name = "GameHistoryForm";
            this.Text = "Buscaminas";
            this.Load += new System.EventHandler(this.GameHistoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label labelWinGamesCount;
        private System.Windows.Forms.Label labelTieGamesCount;
        private System.Windows.Forms.Label labelLostGamesCount;
        private System.Windows.Forms.Label labelWinRate;
        private System.Windows.Forms.Label labelWinRateValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTimePlayedValue;
    }
}