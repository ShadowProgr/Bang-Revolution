namespace Bang_Revolution_Client
{
    partial class frmMain
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
            this.pnlPlayers = new System.Windows.Forms.Panel();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.pnlHand = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pnlPlayers
            // 
            this.pnlPlayers.Location = new System.Drawing.Point(13, 13);
            this.pnlPlayers.Name = "pnlPlayers";
            this.pnlPlayers.Size = new System.Drawing.Size(1110, 373);
            this.pnlPlayers.TabIndex = 0;
            // 
            // pnlActions
            // 
            this.pnlActions.Location = new System.Drawing.Point(13, 392);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(1110, 51);
            this.pnlActions.TabIndex = 1;
            // 
            // pnlHand
            // 
            this.pnlHand.Location = new System.Drawing.Point(13, 449);
            this.pnlHand.Name = "pnlHand";
            this.pnlHand.Size = new System.Drawing.Size(1110, 300);
            this.pnlHand.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1130, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(348, 736);
            this.textBox1.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1490, 761);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pnlHand);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Bang! Revolution";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPlayers;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Panel pnlHand;
        private System.Windows.Forms.TextBox textBox1;
    }
}