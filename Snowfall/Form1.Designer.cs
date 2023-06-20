namespace Snowfall
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
            dataGridView1 = new DataGridView();
            panelMenu = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panelLogo = new Panel();
            labelLogo = new Label();
            panelTitleBar = new Panel();
            label1 = new Label();
            buttonClose = new Button();
            panelDesktop = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelTitleBar.SuspendLayout();
            panelDesktop.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 150, 136);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 150, 136);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(767, 511);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(51, 51, 73);
            panelMenu.Controls.Add(button3);
            panelMenu.Controls.Add(button2);
            panelMenu.Controls.Add(button1);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(217, 561);
            panelMenu.TabIndex = 13;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Top;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.Gainsboro;
            button3.Location = new Point(0, 170);
            button3.Name = "button3";
            button3.Size = new Size(217, 60);
            button3.TabIndex = 3;
            button3.Text = "Настрйоки";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.Gainsboro;
            button2.Location = new Point(0, 110);
            button2.Name = "button2";
            button2.Size = new Size(217, 60);
            button2.TabIndex = 2;
            button2.Text = "Заметки";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Gainsboro;
            button1.Location = new Point(0, 50);
            button1.Name = "button1";
            button1.Size = new Size(217, 60);
            button1.TabIndex = 1;
            button1.Text = "Список дел";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(38, 38, 51);
            panelLogo.Controls.Add(labelLogo);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(217, 50);
            panelLogo.TabIndex = 0;
            // 
            // labelLogo
            // 
            labelLogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelLogo.AutoSize = true;
            labelLogo.Font = new Font("SansSerif", 24F, FontStyle.Regular, GraphicsUnit.Point);
            labelLogo.ForeColor = Color.Gainsboro;
            labelLogo.Location = new Point(37, 9);
            labelLogo.Name = "labelLogo";
            labelLogo.Size = new Size(138, 37);
            labelLogo.TabIndex = 0;
            labelLogo.Text = "Snowfall";
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelTitleBar.Controls.Add(label1);
            panelTitleBar.Controls.Add(buttonClose);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(217, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(767, 50);
            panelTitleBar.TabIndex = 14;
            panelTitleBar.MouseDown += panelTitleBar_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(6, 15);
            label1.Name = "label1";
            label1.Size = new Size(462, 21);
            label1.TabIndex = 1;
            label1.Text = "Здесь будет список категорий, для переключения между ними";
            // 
            // buttonClose
            // 
            buttonClose.BackgroundImage = Properties.Resources.close_icon;
            buttonClose.BackgroundImageLayout = ImageLayout.Stretch;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Location = new Point(728, 12);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(27, 24);
            buttonClose.TabIndex = 0;
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // panelDesktop
            // 
            panelDesktop.Controls.Add(dataGridView1);
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(217, 50);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(767, 511);
            panelDesktop.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(panelDesktop);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Snowfall";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            panelDesktop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private Panel panelMenu;
        private Button button1;
        private Panel panelLogo;
        private Button button2;
        private Panel panelTitleBar;
        private Label labelLogo;
        private Panel panelDesktop;
        private Button button3;
        private Button buttonClose;
        private Label label1;
    }
}