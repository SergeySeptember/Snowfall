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
        //private string[] token = File.ReadAllLines($"{Environment.CurrentDirectory}\\token.json");
        private string[] _token = File.ReadAllLines($"C:\\token.json");
        private string _todoSheet = "Snowfall";
        private bool _successConnect = true;
        private bool _categoryFlag = false;
        private bool _categorySortByTrue = false;
        public Button currentButton;
        private Form _activeForm;
        public FormNotes formNotes;
        public bool languageRus = true;
        public string color = ThemeColor.ColorList[1];

        private IOTasks _iOTasks;
        private IONotes _iONotes;
        private TaskProcessing _taskProcessing = new();
        public BindingList<TaskBody> listOfTasks = new();
        public BindingList<TaskBody> category = new();
        public BindingList<NoteBody> listOfNotes = new();

        public MainForm()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await InitialLoad();
            InitialTheme();
            LanguageTip();
            ColumnsConfig();
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
            {
                _iOTasks.SaveCellEditByCategory(_successConnect, dataGridViewTasks.CurrentCell.RowIndex, category, listOfTasks);
            }
            else
            {
                _iOTasks.SaveCellEdit(_successConnect, dataGridViewTasks.CurrentCell.RowIndex, listOfTasks);
            }
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                listOfTasks.Clear();
                listOfTasks = _iOTasks.LoadAndSortTasks();
                dataGridViewTasks.DataSource = listOfTasks;
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_categoryFlag == true)
            {
                category = _iOTasks.DeleteTaskInCategory(dataGridViewTasks.CurrentCell.RowIndex, listOfTasks, category, _successConnect, _categorySortByTrue);
                dataGridViewTasks.DataSource = category;
            }
            else
            {
                dataGridViewTasks.DataSource = _iOTasks.DeleteTask(dataGridViewTasks.CurrentCell.RowIndex, listOfTasks, _successConnect);
            }
        }

        private void DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
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
            OpenChildForm(new FormNotes(googleHelper, listOfNotes, _successConnect, languageRus, color), sender);
            buttonAll.Visible = false;
            buttonTrue.Visible = false;
            buttonFalse.Visible = false;
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormSettings(this), sender);
            buttonAll.Visible = false;
            buttonTrue.Visible = false;
            buttonFalse.Visible = false;
        }
        private void ButtonAll_Click(object sender, EventArgs e)
        {

            dataGridViewTasks.DataSource = _taskProcessing.FilterTasks(listOfTasks);
            _categoryFlag = false;
        }

        public void ButtonTrue_Click(object sender, EventArgs e)
        {
            category = _taskProcessing.OrderByTrue(listOfTasks);
            dataGridViewTasks.DataSource = category;
            _categoryFlag = true;
            _categorySortByTrue = true;
        }

        private void ButtonFalse_Click(object sender, EventArgs e)
        {
            category = _taskProcessing.OrderByFalse(listOfTasks);
            dataGridViewTasks.DataSource = category;
            _categoryFlag = true;
            _categorySortByTrue = false;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        # region [Theme]
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ColumnsConfig()
        {
            dataGridViewTasks.Columns[0].Width = 460;
            dataGridViewTasks.Columns[1].Width = 50;
            dataGridViewTasks.Columns[2].Width = 100;
            dataGridViewTasks.Columns[3].Width = 160;
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
            buttonList.BackColor = ColorTranslator.FromHtml(color);
            buttonList.ForeColor = Color.White;
            buttonList.Font = new Font("Microsoft Sans Serif", 12.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            panelTitleBar.BackColor = ColorTranslator.FromHtml(color);
        }

        private Color SelectThemeColor()
        {
            return ColorTranslator.FromHtml(color);
        }

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
        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm();
        }

        private void PanelMenu_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm();
        }

        private void PanelLogo_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm();
        }

        private void MoveForm()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
    }
}