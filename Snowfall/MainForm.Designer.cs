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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelMenu = new Panel();
            buttonSettings = new Button();
            buttonNote = new Button();
            buttonList = new Button();
            panelLogo = new Panel();
            labelLogo = new Label();
            buttonAll = new Button();
            panelTitleBar = new Panel();
            buttonMin = new Button();
            buttonClose = new Button();
            buttonFalse = new Button();
            buttonTrue = new Button();
            panelDesktop = new Panel();
            dataGridView1 = new DataGridView();
            contextMenu = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            toolTipAll = new ToolTip(components);
            toolTipTrue = new ToolTip(components);
            toolTipFalse = new ToolTip(components);
            labelOnline = new Label();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelTitleBar.SuspendLayout();
            panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(51, 51, 73);
            panelMenu.Controls.Add(labelOnline);
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
            // buttonAll
            // 
            buttonAll.BackgroundImage = (Image)resources.GetObject("buttonAll.BackgroundImage");
            buttonAll.BackgroundImageLayout = ImageLayout.Stretch;
            buttonAll.FlatAppearance.BorderSize = 0;
            buttonAll.FlatStyle = FlatStyle.Flat;
            buttonAll.Location = new Point(11, 8);
            buttonAll.Name = "buttonAll";
            buttonAll.Size = new Size(35, 35);
            buttonAll.TabIndex = 4;
            toolTipAll.SetToolTip(buttonAll, "Show all tasks");
            buttonAll.UseVisualStyleBackColor = true;
            buttonAll.Click += ButtonAll_Click;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelTitleBar.Controls.Add(buttonMin);
            panelTitleBar.Controls.Add(buttonClose);
            panelTitleBar.Controls.Add(buttonAll);
            panelTitleBar.Controls.Add(buttonFalse);
            panelTitleBar.Controls.Add(buttonTrue);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(217, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(767, 50);
            panelTitleBar.TabIndex = 14;
            panelTitleBar.MouseDown += PanelTitleBar_MouseDown;
            // 
            // buttonMin
            // 
            buttonMin.BackgroundImage = (Image)resources.GetObject("buttonMin.BackgroundImage");
            buttonMin.BackgroundImageLayout = ImageLayout.Stretch;
            buttonMin.FlatAppearance.BorderSize = 0;
            buttonMin.FlatStyle = FlatStyle.Flat;
            buttonMin.Location = new Point(702, 22);
            buttonMin.Name = "buttonMin";
            buttonMin.Size = new Size(20, 20);
            buttonMin.TabIndex = 10;
            buttonMin.UseVisualStyleBackColor = true;
            buttonMin.Click += ButtonMin_Click;
            // 
            // buttonClose
            // 
            buttonClose.BackgroundImage = (Image)resources.GetObject("buttonClose.BackgroundImage");
            buttonClose.BackgroundImageLayout = ImageLayout.Stretch;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Location = new Point(735, 15);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(20, 20);
            buttonClose.TabIndex = 0;
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += ButtonClose_Click;
            // 
            // buttonFalse
            // 
            buttonFalse.BackgroundImage = (Image)resources.GetObject("buttonFalse.BackgroundImage");
            buttonFalse.BackgroundImageLayout = ImageLayout.Stretch;
            buttonFalse.FlatAppearance.BorderSize = 0;
            buttonFalse.FlatStyle = FlatStyle.Flat;
            buttonFalse.Location = new Point(116, 8);
            buttonFalse.Name = "buttonFalse";
            buttonFalse.Size = new Size(35, 35);
            buttonFalse.TabIndex = 5;
            toolTipFalse.SetToolTip(buttonFalse, "Show all pending");
            buttonFalse.UseVisualStyleBackColor = true;
            buttonFalse.Click += ButtonFalse_Click;
            // 
            // buttonTrue
            // 
            buttonTrue.BackgroundImage = (Image)resources.GetObject("buttonTrue.BackgroundImage");
            buttonTrue.BackgroundImageLayout = ImageLayout.Stretch;
            buttonTrue.FlatAppearance.BorderSize = 0;
            buttonTrue.FlatStyle = FlatStyle.Flat;
            buttonTrue.Location = new Point(60, 8);
            buttonTrue.Name = "buttonTrue";
            buttonTrue.Size = new Size(35, 35);
            buttonTrue.TabIndex = 6;
            toolTipTrue.SetToolTip(buttonTrue, "Показать все выполненные");
            buttonTrue.UseVisualStyleBackColor = true;
            buttonTrue.Click += ButtonTrue_Click;
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
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 150, 136);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 150, 136);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(767, 511);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellEndEdit += SaveCellEdit;
            dataGridView1.CellMouseDown += DataGridView1_CellMouseDown;
            // 
            // contextMenu
            // 
            contextMenu.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(107, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            // 
            // labelOnline
            // 
            labelOnline.AutoSize = true;
            labelOnline.Location = new Point(12, 537);
            labelOnline.Name = "labelOnline";
            labelOnline.Size = new Size(38, 15);
            labelOnline.TabIndex = 4;
            labelOnline.Text = "label1";
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
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelTitleBar.ResumeLayout(false);
            panelDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelMenu;
        private Button buttonList;
        private Panel panelLogo;
        private Button buttonNote;
        private Panel panelTitleBar;
        private Label labelLogo;
        private Panel panelDesktop;
        private Button buttonSettings;
        private Button buttonClose;
        private DataGridView dataGridView1;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Button buttonAll;
        private Button buttonTrue;
        private Button buttonFalse;
        private Button buttonMin;
        private ToolTip toolTipAll;
        private ToolTip toolTipFalse;
        private ToolTip toolTipTrue;
        private Label labelOnline;
    }
}