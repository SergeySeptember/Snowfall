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
            cell_1 = new TextBox();
            cell_2 = new TextBox();
            cell_3 = new TextBox();
            cell_4 = new TextBox();
            buttonSet = new Button();
            buttonGet = new Button();
            SuspendLayout();
            // 
            // cell_1
            // 
            cell_1.Location = new Point(28, 52);
            cell_1.Name = "cell_1";
            cell_1.Size = new Size(100, 23);
            cell_1.TabIndex = 1;
            // 
            // cell_2
            // 
            cell_2.Location = new Point(166, 53);
            cell_2.Name = "cell_2";
            cell_2.Size = new Size(100, 23);
            cell_2.TabIndex = 2;
            // 
            // cell_3
            // 
            cell_3.Location = new Point(28, 114);
            cell_3.Name = "cell_3";
            cell_3.Size = new Size(100, 23);
            cell_3.TabIndex = 3;
            // 
            // cell_4
            // 
            cell_4.Location = new Point(166, 114);
            cell_4.Name = "cell_4";
            cell_4.Size = new Size(100, 23);
            cell_4.TabIndex = 4;
            // 
            // buttonSet
            // 
            buttonSet.Enabled = false;
            buttonSet.Location = new Point(309, 52);
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
            buttonGet.Location = new Point(309, 114);
            buttonGet.Name = "buttonGet";
            buttonGet.Size = new Size(75, 23);
            buttonGet.TabIndex = 6;
            buttonGet.Text = "Get";
            buttonGet.UseVisualStyleBackColor = true;
            buttonGet.Click += buttonGet_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 293);
            Controls.Add(buttonGet);
            Controls.Add(buttonSet);
            Controls.Add(cell_4);
            Controls.Add(cell_3);
            Controls.Add(cell_2);
            Controls.Add(cell_1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox cell_1;
        private TextBox cell_2;
        private TextBox cell_3;
        private TextBox cell_4;
        private Button buttonSet;
        private Button buttonGet;
    }
}