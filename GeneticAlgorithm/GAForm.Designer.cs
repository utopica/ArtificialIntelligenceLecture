using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace GeneticAlgorithm
{
    partial class GAForm
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
            label1 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            textBox2 = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            textBox3 = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            textBox4 = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            textBox5 = new System.Windows.Forms.TextBox();
            panel1 = new Panel();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            button1 = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(53, 45);
            label1.Name = "label1";
            label1.Size = new Size(155, 25);
            label1.TabIndex = 0;
            label1.Text = "Popülasyon Boyut";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ControlLight;
            textBox1.Location = new Point(214, 43);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(373, 62);
            label2.Name = "label2";
            label2.Size = new Size(152, 25);
            label2.TabIndex = 2;
            label2.Text = "Çaprazlama Oranı";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ControlLight;
            textBox2.Location = new Point(531, 60);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(63, 94);
            label3.Name = "label3";
            label3.Size = new Size(139, 25);
            label3.TabIndex = 4;
            label3.Text = "Mutasyon Oranı";
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.ControlLight;
            textBox3.Location = new Point(214, 94);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(397, 109);
            label4.Name = "label4";
            label4.Size = new Size(127, 25);
            label4.TabIndex = 6;
            label4.Text = "Seçkinlik Oranı";
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.ControlLight;
            textBox4.Location = new Point(531, 109);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(59, 146);
            label5.Name = "label5";
            label5.Size = new Size(148, 25);
            label5.TabIndex = 8;
            label5.Text = "Jenerasyon Sayısı";
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.ControlLight;
            textBox5.Location = new Point(214, 146);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.ForeColor = SystemColors.ButtonHighlight;
            panel1.Location = new Point(59, 214);
            panel1.Name = "panel1";
            panel1.Size = new Size(829, 253);
            panel1.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(121, 127);
            label10.Name = "label10";
            label10.Size = new Size(0, 20);
            label10.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(121, 91);
            label9.Name = "label9";
            label9.Size = new Size(0, 20);
            label9.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(121, 52);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonHighlight;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.IconChar = FontAwesome.Sharp.IconChar.Edit;
            button1.IconColor = Color.Black;
            button1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button1.ImageAlign = ContentAlignment.TopCenter;
            button1.Location = new Point(749, 62);
            button1.Name = "button1";
            button1.Size = new Size(139, 90);
            button1.TabIndex = 12;
            button1.Text = "ÇÖZ";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // GAForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(995, 501);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(textBox5);
            Controls.Add(label5);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlLightLight;
            Name = "GAForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GAForm";
            Load += GAForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private FontAwesome.Sharp.IconButton button1;
    }
}
