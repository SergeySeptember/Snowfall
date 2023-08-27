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
            labelMode = new Label();
            labelPromo = new Label();
            pictureBoxRus = new PictureBox();
            pictureBoxEng = new PictureBox();
            labelChangeLang = new Label();
            labelColor = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
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
            // labelMode
            // 
            labelMode.AutoSize = true;
            labelMode.Location = new Point(37, 25);
            labelMode.Name = "labelMode";
            labelMode.Size = new Size(124, 15);
            labelMode.TabIndex = 2;
            labelMode.Text = "Светлая/тёмная тема";
            // 
            // labelPromo
            // 
            labelPromo.AutoSize = true;
            labelPromo.Location = new Point(73, 459);
            labelPromo.Name = "labelPromo";
            labelPromo.Size = new Size(118, 30);
            labelPromo.TabIndex = 4;
            labelPromo.Text = "Snowfall 2023\r\nBy Sergey September";
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
            pictureBoxEng.Location = new Point(103, 146);
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
            labelChangeLang.Location = new Point(52, 110);
            labelChangeLang.Name = "labelChangeLang";
            labelChangeLang.Size = new Size(78, 15);
            labelChangeLang.TabIndex = 8;
            labelChangeLang.Text = "Смена языка";
            // 
            // labelColor
            // 
            labelColor.AutoSize = true;
            labelColor.Location = new Point(279, 25);
            labelColor.Name = "labelColor";
            labelColor.Size = new Size(76, 15);
            labelColor.TabIndex = 9;
            labelColor.Text = "Выбор темы";
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
            // button1
            // 
            button1.Location = new Point(265, 59);
            button1.Name = "button1";
            button1.Size = new Size(33, 23);
            button1.TabIndex = 11;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(304, 59);
            button2.Name = "button2";
            button2.Size = new Size(36, 23);
            button2.TabIndex = 12;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(346, 59);
            button3.Name = "button3";
            button3.Size = new Size(38, 23);
            button3.TabIndex = 13;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 508);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(labelColor);
            Controls.Add(labelChangeLang);
            Controls.Add(pictureBoxEng);
            Controls.Add(pictureBoxRus);
            Controls.Add(labelPromo);
            Controls.Add(labelMode);
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
        private Label labelMode;
        private Label labelPromo;
        private PictureBox pictureBoxRus;
        private PictureBox pictureBoxEng;
        private Label labelChangeLang;
        private Label labelColor;
        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}