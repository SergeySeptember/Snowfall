using Snowfall.Entity;
using Snowfall.Forms;
using Snowfall.Service;
using Snowfall.Service.ActionWithNotes;
using Snowfall.Service.ActionWithTasks;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Snowfall
{
    public partial class MainForm : Form
    {
        public GoogleHelper googleHelper;
        private string[] _token = File.ReadAllLines($"{Environment.CurrentDirectory}\\token.json");
        private string _todoSheet = "Snowfall";
        private bool _successConnect = true;
        private bool _categoryFlag = false;
        private bool _categorySortByTrue = false;
        public Button currentButton;
        private Form _activeForm;
        public FormNotes formNotes;
        private bool languageRus = true;
        public string colorUI = ThemeColor.ColorList[1];

        private IOTasks _iOTasks;
        private IONotes _iONotes;
        private TaskProcessing _taskProcessing = new();
        public BindingList<TaskBody> listOfTasks = new();
        public BindingList<TaskBody> category = new();
        public BindingList<NoteBody> listOfNotes = new();

        public bool LanguageRus
        {
            get { return languageRus; }
            set { languageRus = value; FileIOService.SaveSettingsToJson(colorUI, languageRus); }
        }

        public string ColorUI
        {
            get { return colorUI; }
            set { colorUI = value; FileIOService.SaveSettingsToJson(colorUI, languageRus); }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainFormLoad(object sender, EventArgs e)
        {
            string[] settings = FileIOService.ReadSettings();
            colorUI = settings[0];
            languageRus = Convert.ToBoolean(settings[1]);

            await InitialLoad();
            InitialTheme();
            LanguageTip();
            ColumnsConfig();

            if (languageRus)
                Rus();
            else
                Eng();
        }

        private async Task InitialLoad()
        {
            googleHelper = new GoogleHelper(_token[0], _todoSheet);
            _iOTasks = new IOTasks(googleHelper);
            _iONotes = new IONotes(googleHelper);

            try
            {
                _successConnect = await googleHelper.Start();
            }
            catch (Exception ex)
            {
                _successConnect = false;
            }

            if (_successConnect == true)
            {
                listOfTasks = _iOTasks.LoadAndSortTasks();
                dataGridViewTasks.DataSource = listOfTasks;
                listOfNotes = _iONotes.LoadAndSortNotes();

                labelOnline.Text = "Online";
                pictureOnline.Visible = true;
            }
            else
            {
                listOfTasks = _iOTasks.GetTasksFromJson();
                dataGridViewTasks.DataSource = listOfTasks;
                listOfNotes = _iONotes.GetNotesFromJsons();

                labelOnline.Text = "Offline";
                pictureOffline.Visible = true;
            }
        }

        #region [Events]
        private void SaveCellEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_categoryFlag)
                _iOTasks.SaveCellEditByCategory(_successConnect, dataGridViewTasks.CurrentCell.RowIndex, category, listOfTasks);
            else
                _iOTasks.SaveCellEdit(_successConnect, dataGridViewTasks.CurrentCell.RowIndex, listOfTasks);
        }
        private void MainFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                listOfTasks.Clear();
                listOfTasks = _iOTasks.LoadAndSortTasks();
                dataGridViewTasks.DataSource = listOfTasks;
            }
        }

        private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (_categoryFlag == true)
            {
                category = _iOTasks.DeleteTaskInCategory(dataGridViewTasks.CurrentCell.RowIndex, listOfTasks, category, _successConnect, _categorySortByTrue);
                dataGridViewTasks.DataSource = category;
            }
            else
                dataGridViewTasks.DataSource = _iOTasks.DeleteTask(dataGridViewTasks.CurrentCell.RowIndex, listOfTasks, _successConnect);
        }

        private void DataGridViewTasksCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                    if (!c.Selected)
                    {
                        c.DataGridView.ClearSelection();
                        c.DataGridView.CurrentCell = c;
                        c.Selected = true;
                    }

                    Point cursorPosition = dataGridViewTasks.PointToClient(Control.MousePosition);
                    contextMenu.Show(dataGridViewTasks, cursorPosition);
                }
            }
        }

        private void ButtonListClick(object sender, EventArgs e)
        {
            if (_activeForm != null)
                _activeForm.Close();
            Reset();
            ActivateButton(sender);
            buttonAll.Visible = true;
            buttonTrue.Visible = true;
            buttonFalse.Visible = true;
            LanguageTip();
        }

        private void ButtonNoteClick(object sender, EventArgs e)
        {
            OpenChildForm(new FormNotes(googleHelper, listOfNotes, _successConnect, languageRus, colorUI), sender);
            buttonAll.Visible = false;
            buttonTrue.Visible = false;
            buttonFalse.Visible = false;
        }

        private void ButtonSettingsClick(object sender, EventArgs e)
        {
            OpenChildForm(new FormSettings(this), sender);
            buttonAll.Visible = false;
            buttonTrue.Visible = false;
            buttonFalse.Visible = false;
        }
        private void ButtonAllClick(object sender, EventArgs e)
        {

            dataGridViewTasks.DataSource = _taskProcessing.FilterTasks(listOfTasks);
            _categoryFlag = false;
        }

        public void ButtonTrueClick(object sender, EventArgs e)
        {
            category = _taskProcessing.OrderByTrue(listOfTasks);
            dataGridViewTasks.DataSource = category;
            _categoryFlag = true;
            _categorySortByTrue = true;
        }

        private void ButtonFalseClick(object sender, EventArgs e)
        {
            category = _taskProcessing.OrderByFalse(listOfTasks);
            dataGridViewTasks.DataSource = category;
            _categoryFlag = true;
            _categorySortByTrue = false;
        }

        private void ButtonCloseClick(object sender, EventArgs e) => Application.Exit();


        private void ButtonMinClick(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
        #endregion

        # region [Theme]
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Rus()
        {
            LanguageRus = true;
            buttonList.Text = ChangeLanguage.languagesRus["Todo List"];
            buttonNote.Text = ChangeLanguage.languagesRus["Notes"];
            buttonSettings.Text = ChangeLanguage.languagesRus["Settings"];
        }

        private void Eng()
        {
            LanguageRus = false;
            buttonList.Text = ChangeLanguage.languagesEng["Todo List"];
            buttonNote.Text = ChangeLanguage.languagesEng["Notes"];
            buttonSettings.Text = ChangeLanguage.languagesEng["Settings"];
        }

        private void ColumnsConfig()
        {
            dataGridViewTasks.Columns[0].Width = 460;
            dataGridViewTasks.Columns[1].Width = 50;
            dataGridViewTasks.Columns[2].Width = 100;
            dataGridViewTasks.Columns[3].Width = 160;

            dataGridViewTasks.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
        }

        private void LanguageTip()
        {
            if (languageRus)
            {
                toolTipTrue.SetToolTip(buttonTrue, ChangeLanguage.languagesRus["Show completed tasks"]);
                toolTipAll.SetToolTip(buttonAll, ChangeLanguage.languagesRus["Show all tasks"]);
                toolTipFalse.SetToolTip(buttonFalse, ChangeLanguage.languagesRus["Show pending tasks"]);
            }
            else
            {
                toolTipTrue.SetToolTip(buttonTrue, ChangeLanguage.languagesEng["Show completed tasks"]);
                toolTipAll.SetToolTip(buttonAll, ChangeLanguage.languagesEng["Show all tasks"]);
                toolTipFalse.SetToolTip(buttonFalse, ChangeLanguage.languagesEng["Show pending tasks"]);
            }
        }
        private void InitialTheme()
        {
            buttonList.BackColor = ColorTranslator.FromHtml(colorUI);
            buttonList.ForeColor = Color.White;
            buttonList.Font = new Font("Microsoft Sans Serif", 12.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridViewTasks.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(colorUI);
            panelTitleBar.BackColor = ColorTranslator.FromHtml(colorUI);
        }

        private Color SelectThemeColor() => ColorTranslator.FromHtml(colorUI);

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Microsoft Sans Serif", 12.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

            ActivateButton(btnSender);
            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Reset()
        {
            DisableButton();
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
        }
        private void PanelTitleBarMouseDown(object sender, MouseEventArgs e) => MoveForm();

        private void PanelMenuMouseDown(object sender, MouseEventArgs e) => MoveForm();

        private void PanelLogoMouseDown(object sender, MouseEventArgs e) => MoveForm();

        private void MoveForm()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
    }
}