namespace WashingMachine
{
    partial class Form1
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnClose = new FontAwesome.Sharp.IconButton();
            gBoxInput = new GroupBox();
            numericUpDown3 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dataGridView = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            gBoxSonuc = new GroupBox();
            lblDonusHiziSonuc = new Label();
            lblSureSonuc = new Label();
            lblDeterjanSonuc = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnStart = new PictureBox();
            btnRefresh = new FontAwesome.Sharp.IconButton();
            gBoxInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            gBoxSonuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnStart).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = SystemColors.ButtonFace;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnClose.IconColor = Color.Red;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.Location = new Point(1343, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(58, 52);
            btnClose.TabIndex = 0;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // gBoxInput
            // 
            gBoxInput.Controls.Add(numericUpDown3);
            gBoxInput.Controls.Add(numericUpDown2);
            gBoxInput.Controls.Add(numericUpDown1);
            gBoxInput.Controls.Add(label3);
            gBoxInput.Controls.Add(label2);
            gBoxInput.Controls.Add(label1);
            gBoxInput.ForeColor = SystemColors.ControlLightLight;
            gBoxInput.Location = new Point(35, 30);
            gBoxInput.Name = "gBoxInput";
            gBoxInput.Size = new Size(393, 257);
            gBoxInput.TabIndex = 1;
            gBoxInput.TabStop = false;
            gBoxInput.Text = "Giriş Değerleri";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            numericUpDown3.Location = new Point(138, 128);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(80, 25);
            numericUpDown3.TabIndex = 7;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            numericUpDown2.Location = new Point(138, 97);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(80, 25);
            numericUpDown2.TabIndex = 6;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            numericUpDown1.Location = new Point(138, 65);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(80, 25);
            numericUpDown1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 129);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 4;
            label3.Text = "Kirlilik : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 97);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 3;
            label2.Text = "Miktar : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 65);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 2;
            label1.Text = "Hassaslık : ";
            // 
            // dataGridView
            // 
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.ColumnHeadersHeight = 28;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7 });
            dataGridView.Font = new Font("Segoe UI", 8F);
            dataGridView.Location = new Point(457, 40);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 8;
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView.RowTemplate.Height = 20;
            dataGridView.Size = new Size(880, 247);
            dataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "No";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Hassaslık";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Miktar";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Kirlilik";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Dönüş Hızı";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Süre";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Deterjan";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.Width = 125;
            // 
            // gBoxSonuc
            // 
            gBoxSonuc.Controls.Add(lblDonusHiziSonuc);
            gBoxSonuc.Controls.Add(lblSureSonuc);
            gBoxSonuc.Controls.Add(lblDeterjanSonuc);
            gBoxSonuc.Controls.Add(label4);
            gBoxSonuc.Controls.Add(label5);
            gBoxSonuc.Controls.Add(label6);
            gBoxSonuc.ForeColor = SystemColors.ControlLightLight;
            gBoxSonuc.Location = new Point(35, 370);
            gBoxSonuc.Name = "gBoxSonuc";
            gBoxSonuc.Size = new Size(393, 257);
            gBoxSonuc.TabIndex = 2;
            gBoxSonuc.TabStop = false;
            gBoxSonuc.Text = "Sonuçlar";
            // 
            // lblDonusHiziSonuc
            // 
            lblDonusHiziSonuc.AutoSize = true;
            lblDonusHiziSonuc.Location = new Point(138, 129);
            lblDonusHiziSonuc.Name = "lblDonusHiziSonuc";
            lblDonusHiziSonuc.Size = new Size(17, 20);
            lblDonusHiziSonuc.TabIndex = 7;
            lblDonusHiziSonuc.Text = "0";
            // 
            // lblSureSonuc
            // 
            lblSureSonuc.AutoSize = true;
            lblSureSonuc.Location = new Point(100, 97);
            lblSureSonuc.Name = "lblSureSonuc";
            lblSureSonuc.Size = new Size(17, 20);
            lblSureSonuc.TabIndex = 6;
            lblSureSonuc.Text = "0";
            // 
            // lblDeterjanSonuc
            // 
            lblDeterjanSonuc.AutoSize = true;
            lblDeterjanSonuc.Location = new Point(158, 65);
            lblDeterjanSonuc.Name = "lblDeterjanSonuc";
            lblDeterjanSonuc.Size = new Size(17, 20);
            lblDeterjanSonuc.TabIndex = 5;
            lblDeterjanSonuc.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 129);
            label4.Name = "label4";
            label4.Size = new Size(92, 20);
            label4.TabIndex = 4;
            label4.Text = "Dönüş Hızı : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 97);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 3;
            label5.Text = "Süre : ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 65);
            label6.Name = "label6";
            label6.Size = new Size(127, 20);
            label6.TabIndex = 2;
            label6.Text = "Deterjan Miktarı : ";
            // 
            // btnStart
            // 
            btnStart.Image = (Image)resources.GetObject("btnStart.Image");
            btnStart.Location = new Point(130, 664);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(80, 80);
            btnStart.SizeMode = PictureBoxSizeMode.StretchImage;
            btnStart.TabIndex = 0;
            btnStart.TabStop = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Transparent;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = SystemColors.ButtonFace;
            btnRefresh.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            btnRefresh.IconColor = Color.LightSeaGreen;
            btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRefresh.Location = new Point(242, 677);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(58, 52);
            btnRefresh.TabIndex = 3;
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1422, 804);
            Controls.Add(btnRefresh);
            Controls.Add(btnStart);
            Controls.Add(gBoxSonuc);
            Controls.Add(dataGridView);
            Controls.Add(gBoxInput);
            Controls.Add(btnClose);
            ForeColor = SystemColors.ButtonHighlight;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            gBoxInput.ResumeLayout(false);
            gBoxInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            gBoxSonuc.ResumeLayout(false);
            gBoxSonuc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnStart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnClose;
        private GroupBox gBoxInput;
        private Label label2;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private GroupBox gBoxSonuc;
        private Label lblDonusHiziSonuc;
        private Label lblSureSonuc;
        private Label lblDeterjanSonuc;
        private Label label4;
        private Label label5;
        private Label label6;
        private PictureBox btnStart;
        private FontAwesome.Sharp.IconButton btnRefresh;
    }
}
