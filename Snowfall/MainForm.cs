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
        private string[] token = File.ReadAllLines($"C:\\token.json");
        private string todoSheet = "Snowfall";
        private bool successConnect = true;
        private bool categoryFlag = false;
        private bool categorySortByTrue = false;
        private Button currentButton;
        private Form activeForm;
        public FormNotes formNotes;

        private IOTasks iOTasks;
        private IONotes iONotes;
        private TaskProcessing taskProcessing = new();

        public BindingList<TaskBody> listOfTasks = new BindingList<TaskBody>();
        public BindingList<TaskBody> category = new BindingList<TaskBody>();
        public BindingList<NoteBody> listOfNotes = new BindingList<NoteBody>();

        public MainForm()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await InitialLoad();
            ColumnsConfig();
        }

        private async Task InitialLoad()
        {
            googleHelper = new GoogleHelper(token[0], todoSheet);
            iOTasks = new IOTasks(googleHelper);
            iONotes = new IONotes(googleHelper);

            try
            {
                successConnect = await googleHelper.Start();
            }
            catch (Exception ex)
            {
                successConnect = false;
            }

            if (successConnect == true)
            {
                listOfTasks = iOTasks.LoadAndSortTasks();
                dataGridViewTasks.DataSource = listOfTasks;
                listOfNotes = iONotes.LoadAndSortNotes();

                labelOnline.Text = "Online";
            }
            else
            {
                listOfTasks = iOTasks.GetTasksFromJson();
                dataGridViewTasks.DataSource = listOfTasks;
                listOfNotes = iONotes.GetNotesFromJsons();

                labelOnline.Text = "Offline";
            }
        }

        #region [Events]
        private void SaveCellEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (categoryFlag)
            {
                iOTasks.SaveCellEditByCategory(successConnect, dataGridViewTasks.CurrentCell.RowIndex, category, listOfTasks);
            }
            else
            {
                iOTasks.SaveCellEdit(successConnect, dataGridViewTasks.CurrentCell.RowIndex, listOfTasks);
            }
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                listOfTasks.Clear();
                listOfTasks = iOTasks.LoadAndSortTasks();
                dataGridViewTasks.DataSource = listOfTasks;
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (categoryFlag == true)
            {
                category = iOTasks.DeleteTaskInCategory(dataGridViewTasks.CurrentCell.RowIndex, listOfTasks, category, successConnect, categorySortByTrue);
                dataGridViewTasks.DataSource = category;
            }
            else
            {
                dataGridViewTasks.DataSource = iOTasks.DeleteTask(dataGridViewTasks.CurrentCell.RowIndex, listOfTasks, successConnect);
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

        private void ButtonList_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
            ActivateButton(sender);
            buttonAll.Visible = true;
            buttonTrue.Visible = true;
            buttonFalse.Visible = true;
        }

        private void ButtonNote_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNotes(googleHelper, listOfNotes, successConnect), sender);
            buttonAll.Visible = false;
            buttonTrue.Visible = false;
            buttonFalse.Visible = false;
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormSettings(), sender);
            buttonAll.Visible = false;
            buttonTrue.Visible = false;
            buttonFalse.Visible = false;
        }
        private void ButtonAll_Click(object sender, EventArgs e)
        {
            dataGridViewTasks.DataSource = listOfTasks;
            categoryFlag = false;
        }

        public void ButtonTrue_Click(object sender, EventArgs e)
        {
            category = taskProcessing.OrderByTrue(listOfTasks);
            dataGridViewTasks.DataSource = category;
            categoryFlag = true;
            categorySortByTrue = true;
        }

        private void ButtonFalse_Click(object sender, EventArgs e)
        {
            category = taskProcessing.OrderByFalse(listOfTasks);
            dataGridViewTasks.DataSource = category;
            categoryFlag = true;
            categorySortByTrue = false;
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

        private Color SelectThemeColor()
        {
            string color = ThemeColor.ColorList[1];
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
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            ActivateButton(btnSender);
            activeForm = childForm;
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
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
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