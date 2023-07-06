using Snowfall.Entity;
using Snowfall.Forms;
using Snowfall.Service;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Snowfall
{
    public partial class MainForm : Form
    {
        public GoogleHelper googleHelper;
        private string[] token = File.ReadAllLines($"{Environment.CurrentDirectory}\\ListOfTasks.json");
        private string todoSheet = "Snowfall";
        private string pathOfTasks = $"{Environment.CurrentDirectory}\\ListOfTasks.json";
        private string pathOfNotes = $"{Environment.CurrentDirectory}\\ListOfNotes.json";
        private bool successConnect = true;
        private bool categoryFlag = false;
        private bool categorySortByTrue = false;
        private Button currentButton;
        private Form activeForm;
        public FormNotes formNotes;

        private BindingList<TaskBody> listOfTasksGDrive = new BindingList<TaskBody>();
        private BindingList<TaskBody> listOfTasksJSON = new BindingList<TaskBody>();
        private BindingList<TaskBody> listOfTasks = new BindingList<TaskBody>();
        private BindingList<TaskBody> category = new BindingList<TaskBody>();

        BindingList<NoteBody> listOfNotes = new BindingList<NoteBody>();

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

            try
            {
                successConnect = await googleHelper.Start();
            }
            catch (Exception)
            {
                successConnect = false;
            }

            if (successConnect == true)
            {
                int count = googleHelper.GetCountOfNotes();

                LoadAndSortData();

                listOfNotes = googleHelper.GetNotes(cellName: $"A{1}", cellName2: $"B{count}");
                FileIOService.SaveNotesToJson(listOfNotes, pathOfNotes);

                labelOnline.Text = "Online";
            }
            else
            {
                GetTasksFromJson();
                dataGridViewTasks.DataSource = listOfTasksJSON;
                GetNotesFromJsons();
                labelOnline.Text = "Offline";
            }

        }

        private void GetTasksFromGDrive()
        {
            int countOfRawOnGDrive = googleHelper.GetCountOfTasks();
            if (countOfRawOnGDrive != 0)
            {
                listOfTasksGDrive = googleHelper.GetTasks(cellName: $"A{1}", cellName2: $"F{countOfRawOnGDrive}");
            }
        }

        private void LoadAndSortData()
        {
            GetTasksFromGDrive();
            GetTasksFromJson();

            int countOfRawJson = listOfTasksJSON.Count;
            int countOfRawGDrive = listOfTasksGDrive.Count;

            int minCount = Math.Min(countOfRawJson, countOfRawGDrive);

            for (int i = 0; i < minCount; i++)
            {
                var time1 = DateTime.Parse(listOfTasksJSON[i].TimeUpdate);
                var time2 = DateTime.Parse(listOfTasksGDrive[i].TimeUpdate);

                if (time1 > time2)
                {
                    listOfTasks.Add(listOfTasksJSON[i]);
                }
                else
                {
                    listOfTasks.Add(listOfTasksGDrive[i]);
                }
            }

            for (int i = minCount; i < countOfRawJson; i++)
            {
                listOfTasks.Add(listOfTasksJSON[i]);
            }

            for (int i = minCount; i < countOfRawGDrive; i++)
            {
                listOfTasks.Add(listOfTasksGDrive[i]);
            }

            FileIOService.SaveTaskToJson(listOfTasks, pathOfTasks);

            FilterTasks();
        }

        private void FilterTasks()
        {
            var filteredTasks = listOfTasks.Where(b => b.IsDeleted == false).ToList();
            listOfTasks = new BindingList<TaskBody>(filteredTasks);
            dataGridViewTasks.DataSource = listOfTasks;
        }

        private void GetTasksFromJson()
        {
            listOfTasksJSON = FileIOService.LoadTasksFromJson(pathOfTasks);
        }

        private void GetNotesFromJsons()
        {
            listOfNotes = FileIOService.LoadNotesFromJson(pathOfNotes);
        }
        // todo сделать метод, заносит изменения в таблицу. Номер линии не из датагрид, а индексу листа +1
        private void SaveCellEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (categoryFlag == true)
            {
                int index = dataGridViewTasks.CurrentCell.RowIndex;

                if (category.Count > index && !string.IsNullOrWhiteSpace(category[index].Task))
                {
                    string searchTask = category[index].Task;
                    int generalIndex = 0;

                    for (int i = 0; i < listOfTasks.Count; i++)
                    {
                        if (listOfTasks[i].Task == searchTask)
                        {
                            generalIndex = i;
                            break;
                        }
                    }

                    listOfTasks[generalIndex].TimeUpdate = DateTime.Now.ToString();

                    if (successConnect == true)
                    {
                        int lineNumber = generalIndex + 1;

                        googleHelper.SetTasks(
                            cellName1: $"A{lineNumber}", cellName2: $"F{lineNumber}", listOfTasks[generalIndex].Task,
                            listOfTasks[generalIndex].Status.ToString(), listOfTasks[generalIndex].Category,
                            listOfTasks[generalIndex].Time, listOfTasks[generalIndex].TimeUpdate, listOfTasks[generalIndex].IsDeleted.ToString());
                    }

                    RemoveWhiteSpace();

                    FileIOService.SaveTaskToJson(listOfTasks, pathOfTasks);
                }

            }
            else
            {
                int index = dataGridViewTasks.CurrentCell.RowIndex;

                if (listOfTasks.Count > index && !string.IsNullOrWhiteSpace(listOfTasks[index].Task))
                {
                    listOfTasks[index].TimeUpdate = DateTime.Now.ToString();

                    if (successConnect == true)
                    {
                        int lineNumber = dataGridViewTasks.CurrentCell.RowIndex + 1;

                        googleHelper.SetTasks(
                            cellName1: $"A{lineNumber}", cellName2: $"F{lineNumber}", listOfTasks[index].Task,
                            listOfTasks[index].Status.ToString(), listOfTasks[index].Category,
                            listOfTasks[index].Time, listOfTasks[index].TimeUpdate, listOfTasks[index].IsDeleted.ToString());
                    }

                    RemoveWhiteSpace();

                    FileIOService.SaveTaskToJson(listOfTasks, pathOfTasks);
                }
            }
        }

        private void RemoveWhiteSpace()
        {
            for (int i = listOfTasks.Count - 1; i >= 0; i--)
            {
                if (string.IsNullOrWhiteSpace(listOfTasks[i].Task))
                {
                    listOfTasks.RemoveAt(i);
                }
            }
        }

        private void OrderByFalse()
        {
            var filteredTasks = listOfTasks.Where(b => b.Status == false).ToList();
            category = new BindingList<TaskBody>(filteredTasks);
            dataGridViewTasks.DataSource = category;
        }

        private void OrderByTrue()
        {
            var filteredTasks = listOfTasks.Where(b => b.Status == true).ToList();
            category = new BindingList<TaskBody>(filteredTasks);
            dataGridViewTasks.DataSource = category;
        }

        # region [Theme]
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

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
            OpenChildForm(new FormNotes(googleHelper, listOfNotes, successConnect, pathOfNotes), sender);
            buttonAll.Visible = false;
            buttonTrue.Visible = false;
            buttonFalse.Visible = false;
        }
        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSettings(), sender);
            buttonAll.Visible = false;
            buttonTrue.Visible = false;
            buttonFalse.Visible = false;
        }
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                listOfTasks.Clear();
                LoadAndSortData();
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

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (categoryFlag == true)
            {
                int index = dataGridViewTasks.CurrentCell.RowIndex;
                string searchTask = category[index].Task;
                int generalIndex = 0;

                for (int i = 0; i < listOfTasks.Count; i++)
                {
                    if (listOfTasks[i].Task == searchTask)
                    {
                        generalIndex = i;
                        break;
                    }
                }

                listOfTasks[generalIndex].IsDeleted = true;

                if (successConnect == true)
                {
                    int lineNumber = generalIndex + 1;

                    googleHelper.SetTasks(
                        cellName1: $"A{lineNumber}", cellName2: $"F{lineNumber}", listOfTasks[generalIndex].Task,
                        listOfTasks[generalIndex].Status.ToString(), listOfTasks[generalIndex].Category,
                        listOfTasks[generalIndex].Time, listOfTasks[generalIndex].TimeUpdate, listOfTasks[generalIndex].IsDeleted.ToString());
                }

                FileIOService.SaveTaskToJson(listOfTasks, pathOfTasks);

                FilterTasks();

                if (categorySortByTrue = true)
                {
                    OrderByTrue();
                }
                else
                {
                    OrderByFalse();
                }
            }
            else
            {
                int index = dataGridViewTasks.CurrentCell.RowIndex;
                listOfTasks[index].IsDeleted = true;

                if (successConnect == true)
                {
                    int lineNumber = index + 1;

                    googleHelper.SetTasks(
                        cellName1: $"A{lineNumber}", cellName2: $"F{lineNumber}", listOfTasks[index].Task,
                        listOfTasks[index].Status.ToString(), listOfTasks[index].Category,
                        listOfTasks[index].Time, listOfTasks[index].TimeUpdate, listOfTasks[index].IsDeleted.ToString());
                }

                FileIOService.SaveTaskToJson(listOfTasks, pathOfTasks);

                FilterTasks();
            }
        }

        private void ButtonAll_Click(object sender, EventArgs e)
        {
            dataGridViewTasks.DataSource = listOfTasks;
            categoryFlag = false;
        }

        private void ButtonTrue_Click(object sender, EventArgs e)
        {
            OrderByTrue();
            categoryFlag = true;
            categorySortByTrue = true;
        }

        private void ButtonFalse_Click(object sender, EventArgs e)
        {
            OrderByFalse();
            categoryFlag = true;
            categorySortByTrue = false;
        }

    }
}