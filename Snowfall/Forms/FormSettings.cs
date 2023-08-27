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
            mainForm.languageRus = true;
            labelMode.Text = ChangeLanguage.languagesRus["L/D Theme"];
            labelColor.Text = ChangeLanguage.languagesRus["Change color"];
            mainForm.buttonList.Text = ChangeLanguage.languagesRus["Todo List"];
            mainForm.buttonNote.Text = ChangeLanguage.languagesRus["Notes"];
            mainForm.buttonSettings.Text = ChangeLanguage.languagesRus["Settings"];
        }

        private void PictureBoxEngClick(object sender, EventArgs e)
        {
            mainForm.languageRus = false;
            labelMode.Text = ChangeLanguage.languagesEng["L/D Theme"];
            labelColor.Text = ChangeLanguage.languagesEng["Change color"];
            mainForm.buttonList.Text = ChangeLanguage.languagesEng["Todo List"];
            mainForm.buttonNote.Text = ChangeLanguage.languagesEng["Notes"];
            mainForm.buttonSettings.Text = ChangeLanguage.languagesEng["Settings"];

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
