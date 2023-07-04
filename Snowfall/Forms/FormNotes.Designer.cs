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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            textBoxBody = new TextBox();
            buttonAdd = new Button();
            dataGridViewNotes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotes).BeginInit();
            SuspendLayout();
            // 
            // textBoxBody
            // 
            textBoxBody.Location = new Point(221, 12);
            textBoxBody.Multiline = true;
            textBoxBody.Name = "textBoxBody";
            textBoxBody.Size = new Size(518, 427);
            textBoxBody.TabIndex = 1;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(73, 416);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "button1";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += ButtonAddClick;
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
            dataGridViewNotes.Location = new Point(26, 12);
            dataGridViewNotes.Name = "dataGridViewNotes";
            dataGridViewNotes.RowHeadersVisible = false;
            dataGridViewNotes.RowTemplate.Height = 25;
            dataGridViewNotes.ScrollBars = ScrollBars.Vertical;
            dataGridViewNotes.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewNotes.Size = new Size(179, 384);
            dataGridViewNotes.TabIndex = 13;
            dataGridViewNotes.CellClick += dataGridViewNotes_CellClick;
            // 
            // FormNotes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 472);
            Controls.Add(dataGridViewNotes);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxBody);
            Name = "FormNotes";
            Text = "FormNotes";
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxBody;
        private Button buttonAdd;
        private DataGridView dataGridViewNotes;
    }
}