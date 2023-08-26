namespace Snowfall.Forms
{
    partial class FormSettings
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
            checkSwitch1 = new Service.CheckSwitch();
            checkSwitch2 = new Service.CheckSwitch();
            labelMode = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBoxRus = new PictureBox();
            pictureBoxEng = new PictureBox();
            labelChangeLang = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEng).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // checkSwitch1
            // 
            checkSwitch1.AutoSize = true;
            checkSwitch1.Location = new Point(70, 52);
            checkSwitch1.MinimumSize = new Size(45, 22);
            checkSwitch1.Name = "checkSwitch1";
            checkSwitch1.OffBackColor = Color.Gray;
            checkSwitch1.OffToggleColor = Color.Gainsboro;
            checkSwitch1.OnBackColor = Color.MediumSlateBlue;
            checkSwitch1.OnToggleColor = Color.WhiteSmoke;
            checkSwitch1.Size = new Size(45, 22);
            checkSwitch1.TabIndex = 0;
            checkSwitch1.UseVisualStyleBackColor = true;
            // 
            // checkSwitch2
            // 
            checkSwitch2.AutoSize = true;
            checkSwitch2.Location = new Point(201, 52);
            checkSwitch2.MinimumSize = new Size(45, 22);
            checkSwitch2.Name = "checkSwitch2";
            checkSwitch2.OffBackColor = Color.Gray;
            checkSwitch2.OffToggleColor = Color.Gainsboro;
            checkSwitch2.OnBackColor = Color.MediumSlateBlue;
            checkSwitch2.OnToggleColor = Color.WhiteSmoke;
            checkSwitch2.Size = new Size(45, 22);
            checkSwitch2.TabIndex = 1;
            checkSwitch2.UseVisualStyleBackColor = true;
            // 
            // labelMode
            // 
            labelMode.AutoSize = true;
            labelMode.Location = new Point(37, 25);
            labelMode.Name = "labelMode";
            labelMode.Size = new Size(124, 15);
            labelMode.TabIndex = 2;
            labelMode.Text = "Светлая/тёмная тема";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(208, 25);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 3;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 459);
            label3.Name = "label3";
            label3.Size = new Size(118, 30);
            label3.TabIndex = 4;
            label3.Text = "Snowfall 2023\r\nBy Sergey September";
            // 
            // pictureBoxRus
            // 
            pictureBoxRus.Image = Properties.Resources.rus;
            pictureBoxRus.Location = new Point(37, 146);
            pictureBoxRus.Name = "pictureBoxRus";
            pictureBoxRus.Size = new Size(40, 40);
            pictureBoxRus.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRus.TabIndex = 6;
            pictureBoxRus.TabStop = false;
            pictureBoxRus.Click += PictureBoxRusClick;
            // 
            // pictureBoxEng
            // 
            pictureBoxEng.Image = Properties.Resources.eng;
            pictureBoxEng.Location = new Point(99, 146);
            pictureBoxEng.Name = "pictureBoxEng";
            pictureBoxEng.Size = new Size(40, 40);
            pictureBoxEng.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxEng.TabIndex = 7;
            pictureBoxEng.TabStop = false;
            pictureBoxEng.Click += PictureBoxEngClick;
            // 
            // labelChangeLang
            // 
            labelChangeLang.AutoSize = true;
            labelChangeLang.Location = new Point(47, 111);
            labelChangeLang.Name = "labelChangeLang";
            labelChangeLang.Size = new Size(78, 15);
            labelChangeLang.TabIndex = 8;
            labelChangeLang.Text = "Смена языка";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(358, 25);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 9;
            label5.Text = "Выбор темы";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.github_mark;
            pictureBox1.Location = new Point(12, 441);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 508);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(labelChangeLang);
            Controls.Add(pictureBoxEng);
            Controls.Add(pictureBoxRus);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(labelMode);
            Controls.Add(checkSwitch2);
            Controls.Add(checkSwitch1);
            Name = "FormSettings";
            Text = "FormSettings";
            ((System.ComponentModel.ISupportInitialize)pictureBoxRus).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEng).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Service.CheckSwitch checkSwitch1;
        private Service.CheckSwitch checkSwitch2;
        private Label labelMode;
        private Label label2;
        private Label label3;
        private PictureBox pictureBoxRus;
        private PictureBox pictureBoxEng;
        private Label labelChangeLang;
        private Label label5;
        private PictureBox pictureBox1;
    }
}