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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
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
            textBoxBody.Location = new Point(221, 12);
            textBoxBody.Multiline = true;
            textBoxBody.Name = "textBoxBody";
            textBoxBody.Size = new Size(518, 448);
            textBoxBody.TabIndex = 1;
            textBoxBody.KeyDown += textBoxBody_KeyDown;
            // 
            // dataGridViewNotes
            // 
            dataGridViewNotes.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewNotes.BorderStyle = BorderStyle.None;
            dataGridViewNotes.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 150, 136);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridViewNotes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 150, 136);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridViewNotes.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewNotes.Location = new Point(26, 12);
            dataGridViewNotes.Name = "dataGridViewNotes";
            dataGridViewNotes.RowHeadersVisible = false;
            dataGridViewNotes.RowTemplate.Height = 25;
            dataGridViewNotes.ScrollBars = ScrollBars.Vertical;
            dataGridViewNotes.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewNotes.Size = new Size(179, 448);
            dataGridViewNotes.TabIndex = 13;
            dataGridViewNotes.CellClick += dataGridViewNotes_CellClick;
            dataGridViewNotes.CellEndEdit += dataGridViewNotes_CellEndEdit;
            dataGridViewNotes.CellMouseDown += dataGridViewNotes_CellMouseDown;
            // 
            // contextMenu
            // 
            contextMenu.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(181, 48);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(180, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // FormNotes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 472);
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