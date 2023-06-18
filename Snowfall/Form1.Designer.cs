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
            buttonSet = new Button();
            buttonGet = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buttonSet
            // 
            buttonSet.Enabled = false;
            buttonSet.Location = new Point(690, 29);
            buttonSet.Name = "buttonSet";
            buttonSet.Size = new Size(75, 23);
            buttonSet.TabIndex = 5;
            buttonSet.Text = "Set";
            buttonSet.UseVisualStyleBackColor = true;
            buttonSet.Click += buttonSet_Click;
            // 
            // buttonGet
            // 
            buttonGet.Enabled = false;
            buttonGet.Location = new Point(690, 82);
            buttonGet.Name = "buttonGet";
            buttonGet.Size = new Size(75, 23);
            buttonGet.TabIndex = 6;
            buttonGet.Text = "Get";
            buttonGet.UseVisualStyleBackColor = true;
            buttonGet.Click += buttonGet_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(656, 414);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 453);
            Controls.Add(dataGridView1);
            Controls.Add(buttonGet);
            Controls.Add(buttonSet);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonSet;
        private Button buttonGet;
        private DataGridView dataGridView1;
    }
}