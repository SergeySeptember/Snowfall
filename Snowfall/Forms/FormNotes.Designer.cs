namespace Snowfall.Forms
{
    partial class FormNotes
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            textBoxBody = new TextBox();
            dataGridViewNotes = new DataGridView();
            contextMenu = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotes).BeginInit();
            contextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxBody
            // 
            textBoxBody.Location = new Point(40, 1);
            textBoxBody.Multiline = true;
            textBoxBody.Name = "textBoxBody";
            textBoxBody.Size = new Size(708, 495);
            textBoxBody.TabIndex = 1;
            textBoxBody.KeyDown += TextBoxBodyKeyDown;
            // 
            // dataGridViewNotes
            // 
            dataGridViewNotes.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewNotes.BorderStyle = BorderStyle.None;
            dataGridViewNotes.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 150, 136);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewNotes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 150, 136);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewNotes.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewNotes.Location = new Point(-138, 1);
            dataGridViewNotes.Name = "dataGridViewNotes";
            dataGridViewNotes.RowHeadersVisible = false;
            dataGridViewNotes.RowTemplate.Height = 25;
            dataGridViewNotes.ScrollBars = ScrollBars.Vertical;
            dataGridViewNotes.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewNotes.Size = new Size(172, 495);
            dataGridViewNotes.TabIndex = 13;
            dataGridViewNotes.CellClick += DataGridViewNotesCellClick;
            dataGridViewNotes.CellEndEdit += DataGridViewNotesCellEndEdit;
            dataGridViewNotes.CellMouseDown += DataGridViewNotesCellMouseDown;
            dataGridViewNotes.MouseEnter += DataGridViewNotesMouseEnter;
            dataGridViewNotes.MouseLeave += DataGridViewNotesMouseLeave;
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
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItemClick;
            // 
            // FormNotes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 508);
            Controls.Add(dataGridViewNotes);
            Controls.Add(textBoxBody);
            Name = "FormNotes";
            Text = "FormNotes";
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotes).EndInit();
            contextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxBody;
        private DataGridView dataGridViewNotes;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}