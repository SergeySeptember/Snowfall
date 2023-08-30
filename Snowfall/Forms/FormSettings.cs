using Snowfall.Service;
using System.Diagnostics;

namespace Snowfall.Forms
{
    public partial class FormSettings : Form
    {
        private MainForm _mainForm;
        public FormSettings(MainForm owner)
        {
            _mainForm = owner;
            InitializeComponent();

            if (_mainForm.LanguageRus)
            {
                labelColor.Text = ChangeLanguage.languagesRus["Change color"];
                labelChangeLang.Text = ChangeLanguage.languagesRus["Change Language"];
            }
            else
            {
                labelColor.Text = ChangeLanguage.languagesEng["Change color"];
                labelChangeLang.Text = ChangeLanguage.languagesEng["Change Language"];
            }
        }

        private void PictureBoxLogoClick(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/SergeySeptember/Snowfall",
                UseShellExecute = true
            });
        }

        private void PictureBoxRusClick(object sender, EventArgs e)
        {
            _mainForm.LanguageRus = true;
            labelColor.Text = ChangeLanguage.languagesRus["Change color"];
            labelChangeLang.Text = ChangeLanguage.languagesRus["Change Language"];
            _mainForm.buttonList.Text = ChangeLanguage.languagesRus["Todo List"];
            _mainForm.buttonNote.Text = ChangeLanguage.languagesRus["Notes"];
            _mainForm.buttonSettings.Text = ChangeLanguage.languagesRus["Settings"];
        }

        private void PictureBoxEngClick(object sender, EventArgs e)
        {
            _mainForm.LanguageRus = false;
            labelColor.Text = ChangeLanguage.languagesEng["Change color"];
            labelChangeLang.Text = ChangeLanguage.languagesEng["Change Language"];
            _mainForm.buttonList.Text = ChangeLanguage.languagesEng["Todo List"];
            _mainForm.buttonNote.Text = ChangeLanguage.languagesEng["Notes"];
            _mainForm.buttonSettings.Text = ChangeLanguage.languagesEng["Settings"];
        }

        private void ChangeColor(int index)
        {
            _mainForm.ColorUI = ThemeColor.ColorList[index];
            _mainForm.panelTitleBar.BackColor = ColorTranslator.FromHtml(ThemeColor.ColorList[index]);
            _mainForm.currentButton.BackColor = ColorTranslator.FromHtml(ThemeColor.ColorList[index]);
            _mainForm.dataGridViewTasks.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(ThemeColor.ColorList[index]);
        }

        #region [PictureBoxClick]
        private void PictureBox1Click(object sender, EventArgs e) => ChangeColor(0);

        private void PictureBox2Click(object sender, EventArgs e) => ChangeColor(1);

        private void PictureBox3Click(object sender, EventArgs e) => ChangeColor(2);

        private void PictureBox4Click(object sender, EventArgs e) => ChangeColor(3);

        private void PictureBox5Click(object sender, EventArgs e) => ChangeColor(4);

        private void PictureBox6Click(object sender, EventArgs e) => ChangeColor(5);

        private void PictureBox7Click(object sender, EventArgs e) => ChangeColor(6);

        private void PictureBox8Click(object sender, EventArgs e) => ChangeColor(7);

        private void PictureBox9Click(object sender, EventArgs e) => ChangeColor(8);
        #endregion
    }
}
