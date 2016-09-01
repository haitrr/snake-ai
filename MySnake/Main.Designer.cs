namespace MySnake
{
    partial class Main
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
            this.PNGame = new System.Windows.Forms.Panel();
            this.TMDelay = new System.Windows.Forms.Timer(this.components);
            this.LBDelayTime = new System.Windows.Forms.Label();
            this.lbLength = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PNGame
            // 
            this.PNGame.Location = new System.Drawing.Point(12, 12);
            this.PNGame.Name = "PNGame";
            this.PNGame.Size = new System.Drawing.Size(901, 451);
            this.PNGame.TabIndex = 0;
            this.PNGame.Paint += new System.Windows.Forms.PaintEventHandler(this.PNGame_Paint);
            // 
            // TMDelay
            // 
            this.TMDelay.Tick += new System.EventHandler(this.TMDelay_Tick);
            // 
            // LBDelayTime
            // 
            this.LBDelayTime.AutoSize = true;
            this.LBDelayTime.Location = new System.Drawing.Point(221, 470);
            this.LBDelayTime.Name = "LBDelayTime";
            this.LBDelayTime.Size = new System.Drawing.Size(57, 13);
            this.LBDelayTime.TabIndex = 2;
            this.LBDelayTime.Text = "TimeDelay";
            // 
            // lbLength
            // 
            this.lbLength.AutoSize = true;
            this.lbLength.Location = new System.Drawing.Point(56, 470);
            this.lbLength.Name = "lbLength";
            this.lbLength.Size = new System.Drawing.Size(40, 13);
            this.lbLength.TabIndex = 3;
            this.lbLength.Text = "Length";
            this.lbLength.Click += new System.EventHandler(this.lbLength_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 493);
            this.Controls.Add(this.lbLength);
            this.Controls.Add(this.LBDelayTime);
            this.Controls.Add(this.PNGame);
            this.Name = "Main";
            this.Text = "My snake";
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PNGame;
        private System.Windows.Forms.Timer TMDelay;
        private System.Windows.Forms.Label LBDelayTime;
        private System.Windows.Forms.Label lbLength;
    }
}

