using System.Windows.Forms;

namespace EightPuzzleAStarSolution
{
    partial class EightPuzzle
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnClose = new FontAwesome.Sharp.IconButton();
            panel = new Panel();
            btn0 = new Button();
            btn8 = new Button();
            btn7 = new Button();
            btn6 = new Button();
            btn5 = new Button();
            btn4 = new Button();
            btn3 = new Button();
            btn2 = new Button();
            btn1 = new Button();
            btnStart = new FontAwesome.Sharp.IconButton();
            btnRestart = new FontAwesome.Sharp.IconButton();
            lblStart = new Label();
            lblRestart = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            lblTimer = new Label();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.BackColor = SystemColors.WindowText;
            btnClose.FlatAppearance.BorderColor = SystemColors.Control;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = SystemColors.Window;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnClose.IconColor = Color.Red;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.Location = new Point(976, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(42, 46);
            btnClose.TabIndex = 0;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += GameControlButton_Click;
            // 
            // panel
            // 
            panel.BorderStyle = BorderStyle.Fixed3D;
            panel.Controls.Add(btn0);
            panel.Controls.Add(btn8);
            panel.Controls.Add(btn7);
            panel.Controls.Add(btn6);
            panel.Controls.Add(btn5);
            panel.Controls.Add(btn4);
            panel.Controls.Add(btn3);
            panel.Controls.Add(btn2);
            panel.Controls.Add(btn1);
            panel.Location = new Point(198, 75);
            panel.Name = "panel";
            panel.Size = new Size(593, 593);
            panel.TabIndex = 1;
            // 
            // btn0
            // 
            btn0.BackColor = SystemColors.WindowText;
            btn0.FlatAppearance.BorderSize = 0;
            btn0.FlatStyle = FlatStyle.Flat;
            btn0.Font = new Font("Segoe UI", 22F);
            btn0.ForeColor = SystemColors.InactiveCaptionText;
            btn0.Location = new Point(395, 395);
            btn0.Name = "btn0";
            btn0.Size = new Size(190, 190);
            btn0.TabIndex = 9;
            btn0.UseVisualStyleBackColor = false;
            // 
            // btn8
            // 
            btn8.BackColor = Color.FloralWhite;
            btn8.FlatAppearance.BorderSize = 0;
            btn8.FlatStyle = FlatStyle.Flat;
            btn8.Font = new Font("Segoe UI", 22F);
            btn8.ForeColor = SystemColors.InactiveCaptionText;
            btn8.Location = new Point(199, 395);
            btn8.Name = "btn8";
            btn8.Size = new Size(190, 190);
            btn8.TabIndex = 8;
            btn8.Text = "";
            btn8.UseVisualStyleBackColor = false;
            // 
            // btn7
            // 
            btn7.BackColor = Color.FloralWhite;
            btn7.FlatAppearance.BorderSize = 0;
            btn7.FlatStyle = FlatStyle.Flat;
            btn7.Font = new Font("Segoe UI", 22F);
            btn7.ForeColor = SystemColors.InactiveCaptionText;
            btn7.Location = new Point(3, 395);
            btn7.Name = "btn7";
            btn7.Size = new Size(190, 190);
            btn7.TabIndex = 6;
            btn7.Text = "";
            btn7.UseVisualStyleBackColor = false;
            // 
            // btn6
            // 
            btn6.BackColor = Color.FloralWhite;
            btn6.FlatAppearance.BorderSize = 0;
            btn6.FlatStyle = FlatStyle.Flat;
            btn6.Font = new Font("Segoe UI", 22F);
            btn6.ForeColor = SystemColors.InactiveCaptionText;
            btn6.Location = new Point(395, 199);
            btn6.Name = "btn6";
            btn6.Size = new Size(190, 190);
            btn6.TabIndex = 5;
            btn6.Text = "";
            btn6.UseVisualStyleBackColor = false;
            // 
            // btn5
            // 
            btn5.BackColor = Color.FloralWhite;
            btn5.FlatAppearance.BorderSize = 0;
            btn5.FlatStyle = FlatStyle.Flat;
            btn5.Font = new Font("Segoe UI", 22F);
            btn5.ForeColor = SystemColors.InactiveCaptionText;
            btn5.Location = new Point(199, 199);
            btn5.Name = "btn5";
            btn5.Size = new Size(190, 190);
            btn5.TabIndex = 4;
            btn5.Text = "";
            btn5.UseVisualStyleBackColor = false;
            // 
            // btn4
            // 
            btn4.BackColor = Color.FloralWhite;
            btn4.FlatAppearance.BorderSize = 0;
            btn4.FlatStyle = FlatStyle.Flat;
            btn4.Font = new Font("Segoe UI", 22F);
            btn4.ForeColor = SystemColors.InactiveCaptionText;
            btn4.Location = new Point(3, 199);
            btn4.Name = "btn4";
            btn4.Size = new Size(190, 190);
            btn4.TabIndex = 3;
            btn4.Text = "";
            btn4.UseVisualStyleBackColor = false;
            // 
            // btn3
            // 
            btn3.BackColor = Color.FloralWhite;
            btn3.FlatAppearance.BorderSize = 0;
            btn3.FlatStyle = FlatStyle.Flat;
            btn3.Font = new Font("Segoe UI", 22F);
            btn3.ForeColor = SystemColors.InactiveCaptionText;
            btn3.Location = new Point(395, 3);
            btn3.Name = "btn3";
            btn3.Size = new Size(190, 190);
            btn3.TabIndex = 2;
            btn3.Text = "";
            btn3.UseVisualStyleBackColor = false;
            // 
            // btn2
            // 
            btn2.BackColor = Color.FloralWhite;
            btn2.FlatAppearance.BorderSize = 0;
            btn2.FlatStyle = FlatStyle.Flat;
            btn2.Font = new Font("Segoe UI", 22F);
            btn2.ForeColor = SystemColors.InactiveCaptionText;
            btn2.Location = new Point(199, 3);
            btn2.Name = "btn2";
            btn2.Size = new Size(190, 190);
            btn2.TabIndex = 1;
            btn2.Text = "";
            btn2.UseVisualStyleBackColor = false;
            // 
            // btn1
            // 
            btn1.BackColor = Color.FloralWhite;
            btn1.FlatAppearance.BorderSize = 0;
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.Font = new Font("Segoe UI", 22F);
            btn1.ForeColor = SystemColors.InactiveCaptionText;
            btn1.Location = new Point(3, 3);
            btn1.Name = "btn1";
            btn1.Size = new Size(190, 190);
            btn1.TabIndex = 0;
            btn1.Text = "";
            btn1.UseVisualStyleBackColor = false;
            // 
            // btnStart
            // 
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnStart.IconColor = Color.Green;
            btnStart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStart.IconSize = 72;
            btnStart.Location = new Point(399, 694);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(87, 75);
            btnStart.TabIndex = 2;
            btnStart.TextAlign = ContentAlignment.BottomCenter;
            btnStart.UseVisualStyleBackColor = true;
            // 
            // btnRestart
            // 
            btnRestart.FlatAppearance.BorderSize = 0;
            btnRestart.FlatStyle = FlatStyle.Flat;
            btnRestart.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateLeft;
            btnRestart.IconColor = Color.DodgerBlue;
            btnRestart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRestart.IconSize = 75;
            btnRestart.Location = new Point(511, 694);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(87, 75);
            btnRestart.TabIndex = 3;
            btnRestart.TextAlign = ContentAlignment.BottomCenter;
            btnRestart.UseVisualStyleBackColor = true;
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblStart.Location = new Point(399, 772);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(82, 31);
            lblStart.TabIndex = 4;
            lblStart.Text = "START";
            // 
            // lblRestart
            // 
            lblRestart.AutoSize = true;
            lblRestart.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblRestart.Location = new Point(502, 772);
            lblRestart.Name = "lblRestart";
            lblRestart.Size = new Size(109, 31);
            lblRestart.TabIndex = 5;
            lblRestart.Text = "RESTART";
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTimer.Location = new Point(40, 27);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(72, 31);
            lblTimer.TabIndex = 6;
            lblTimer.Text = "00:00";
            // 
            // EightPuzzle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowText;
            ClientSize = new Size(1030, 839);
            Controls.Add(lblTimer);
            Controls.Add(lblRestart);
            Controls.Add(lblStart);
            Controls.Add(btnRestart);
            Controls.Add(btnStart);
            Controls.Add(panel);
            Controls.Add(btnClose);
            ForeColor = SystemColors.ControlLightLight;
            FormBorderStyle = FormBorderStyle.None;
            Name = "EightPuzzle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EightPuzzleGame";
            panel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnClose;
        private Panel panel;
        private Button btn4;
        private Button btn3;
        private Button btn2;
        private Button btn1;
        private Button btn7;
        private Button btn6;
        private Button btn5;
        private Button btn8;
        private FontAwesome.Sharp.IconButton btnStart;
        private FontAwesome.Sharp.IconButton btnRestart;
        private Label lblStart;
        private Label lblRestart;
        private System.Windows.Forms.Timer timer1;
        private Label lblTimer;
        private Button btn0;
    }
}
