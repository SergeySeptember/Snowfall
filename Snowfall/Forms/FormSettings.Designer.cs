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
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // checkSwitch1
            // 
            checkSwitch1.AutoSize = true;
            checkSwitch1.Location = new Point(89, 78);
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
            checkSwitch2.Location = new Point(89, 146);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 50);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 2;
            label1.Text = "Light\\Dark mode";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(96, 119);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 3;
            label2.Text = "label2";
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 472);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkSwitch2);
            Controls.Add(checkSwitch1);
            Name = "FormSettings";
            Text = "FormSettings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Service.CheckSwitch checkSwitch1;
        private Service.CheckSwitch checkSwitch2;
        private Label label1;
        private Label label2;
    }
}