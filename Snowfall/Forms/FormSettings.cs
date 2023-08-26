using Snowfall.Service;
using System.Diagnostics;
using System.Security.Policy;

namespace Snowfall.Forms
{
    public partial class FormSettings : Form
    {
        MainForm mainForm;
        public FormSettings(MainForm owner)
        {
            this.mainForm = owner;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/SergeySeptember/Snowfall",
                UseShellExecute = true
            });
        }

        private void PictureBoxRusClick(object sender, EventArgs e)
        {
            labelMode.Text = ChangeLanguage.languagesRus["L/D Theme"];
        }

        private void PictureBoxEngClick(object sender, EventArgs e)
        {
            labelMode.Text = ChangeLanguage.languagesEng["L/D Theme"];
            mainForm.buttonList.Text = "ToDo List";
            mainForm.languageRus = false;
        }
    }
}
