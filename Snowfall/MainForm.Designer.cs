namespace Snowfall
{
    partial class MainForm
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
            buttonTest = new Button();
            buttonSettings = new Button();
            buttonNote = new Button();
            buttonList = new Button();
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
            dataGridView1.CellEndEdit += SaveCellEditAsync;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(51, 51, 73);
            panelMenu.Controls.Add(buttonTest);
            panelMenu.Controls.Add(buttonSettings);
            panelMenu.Controls.Add(buttonNote);
            panelMenu.Controls.Add(buttonList);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(217, 561);
            panelMenu.TabIndex = 13;
            panelMenu.MouseDown += PanelMenu_MouseDown;
            // 
            // buttonTest
            // 
            buttonTest.Dock = DockStyle.Top;
            buttonTest.FlatAppearance.BorderSize = 0;
            buttonTest.FlatStyle = FlatStyle.Flat;
            buttonTest.ForeColor = Color.Gainsboro;
            buttonTest.Location = new Point(0, 243);
            buttonTest.Name = "buttonTest";
            buttonTest.Size = new Size(217, 60);
            buttonTest.TabIndex = 4;
            buttonTest.Text = "Test";
            buttonTest.UseVisualStyleBackColor = true;
            buttonTest.Click += buttonTest_Click;
            // 
            // buttonSettings
            // 
            buttonSettings.Dock = DockStyle.Top;
            buttonSettings.FlatAppearance.BorderSize = 0;
            buttonSettings.FlatStyle = FlatStyle.Flat;
            buttonSettings.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSettings.ForeColor = Color.Gainsboro;
            buttonSettings.Location = new Point(0, 183);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(217, 60);
            buttonSettings.TabIndex = 3;
            buttonSettings.Text = "Настрйоки";
            buttonSettings.UseVisualStyleBackColor = true;
            buttonSettings.Click += ButtonSettings_Click;
            // 
            // buttonNote
            // 
            buttonNote.Dock = DockStyle.Top;
            buttonNote.FlatAppearance.BorderSize = 0;
            buttonNote.FlatStyle = FlatStyle.Flat;
            buttonNote.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            buttonNote.ForeColor = Color.Gainsboro;
            buttonNote.Location = new Point(0, 123);
            buttonNote.Name = "buttonNote";
            buttonNote.Size = new Size(217, 60);
            buttonNote.TabIndex = 2;
            buttonNote.Text = "Заметки";
            buttonNote.UseVisualStyleBackColor = true;
            buttonNote.Click += ButtonNote_Click;
            // 
            // buttonList
            // 
            buttonList.Dock = DockStyle.Top;
            buttonList.FlatAppearance.BorderSize = 0;
            buttonList.FlatStyle = FlatStyle.Flat;
            buttonList.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            buttonList.ForeColor = Color.Gainsboro;
            buttonList.Location = new Point(0, 63);
            buttonList.Name = "buttonList";
            buttonList.Size = new Size(217, 60);
            buttonList.TabIndex = 1;
            buttonList.Text = "Список дел";
            buttonList.UseVisualStyleBackColor = true;
            buttonList.Click += ButtonList_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(38, 38, 51);
            panelLogo.Controls.Add(labelLogo);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(217, 63);
            panelLogo.TabIndex = 0;
            panelLogo.MouseDown += PanelLogo_MouseDown;
            // 
            // labelLogo
            // 
            labelLogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelLogo.AutoSize = true;
            labelLogo.Font = new Font("SansSerif", 24F, FontStyle.Regular, GraphicsUnit.Point);
            labelLogo.ForeColor = Color.Gainsboro;
            labelLogo.Location = new Point(39, 13);
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
            panelTitleBar.MouseDown += PanelTitleBar_MouseDown;
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
            buttonClose.Click += ButtonClose_Click;
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(panelDesktop);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Snowfall";
            Load += Form1_Load;
            KeyDown += MainForm_KeyDown;
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
        private Button buttonList;
        private Panel panelLogo;
        private Button buttonNote;
        private Panel panelTitleBar;
        private Label labelLogo;
        private Panel panelDesktop;
        private Button buttonSettings;
        private Button buttonClose;
        private Label label1;
        private Button buttonTest;
    }
}