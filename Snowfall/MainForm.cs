using Snowfall.Service;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Snowfall
{
    public partial class MainForm : Form
    {
        private GoogleHelper googleHelper;
        private string[] token = File.ReadAllLines(@"C:\Users\September\source\repos\Snowfall\Documents\token.json");
        private string todoSheet = "Snowfall";
        private string pathOfTasks = $"{Environment.CurrentDirectory}\\ListOfTasks.json";
        private bool successConnect = true;
        private Button currentButton;
        private Form activeForm;

        private BindingList<TaskBody> listOfTasksGDrive = new BindingList<TaskBody>();
        private BindingList<TaskBody> listOfTasksJSON = new BindingList<TaskBody>();
        private BindingList<TaskBody> listOfTasks = new BindingList<TaskBody>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitialLoad();

            dataGridView1.DataSource = listOfTasks;

            ColumnsConfig();
        }

        private void InitialLoad()
        {
            googleHelper = new GoogleHelper(token[0], todoSheet);

            try
            {
                successConnect = this.googleHelper.Start().Result;
            }
            catch (Exception)
            {
                successConnect = false;
            }

            if (successConnect == true)
                LoadAndSortData();
            else
                LoadDataFromJson();
        }

        private void LoadDataFromGDrive()
        {
            int countOfRawOnGDrive = googleHelper.GetCountOfRaws(cellName: "A", cellName2: "A");
            if (countOfRawOnGDrive != 0)
            {
                listOfTasksGDrive = googleHelper.Get(cellName: $"A{1}", cellName2: $"E{countOfRawOnGDrive}");
            }
        }

        private void LoadAndSortData()
        {
            LoadDataFromGDrive();
            LoadDataFromJson();

            int countOfRawGDrive = listOfTasksGDrive.Count;
            int countOfRawJson = listOfTasksJSON.Count;

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
        }

        private void LoadDataFromJson()
        {
            listOfTasksJSON = FileIOService.LoadData(pathOfTasks);
        }

        private void EditTask(int index, TaskBody currentTaskBody)
        {
            if (listOfTasks.Count < index)
            {
                listOfTasks.Add(currentTaskBody);
            }
            else
            {
                listOfTasks[index].Task = currentTaskBody.Task;
                listOfTasks[index].Status = currentTaskBody.Status;
                listOfTasks[index].Category = currentTaskBody.Category;
                listOfTasks[index].Time = currentTaskBody.Time;
                listOfTasks[index].TimeUpdate = DateTime.Now.ToString();
            }
        }

        private async void SaveCellEditAsync(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            if (listOfTasks.Count > index && !string.IsNullOrWhiteSpace(listOfTasks[index].Task))
            {
                var currentTaskBody = listOfTasks[index];

                EditTask(index, currentTaskBody);

                if (successConnect == true)
                {
                    int lineNumber = dataGridView1.CurrentCell.RowIndex + 1;
                    var taskBody = listOfTasks[index];

                    googleHelper.Set(cellName1: $"A{lineNumber}", cellName2: $"E{lineNumber}", taskBody.Task, taskBody.Status.ToString(), taskBody.Category, taskBody.Time, taskBody.TimeUpdate = DateTime.Now.ToString());
                }

                for (int i = listOfTasks.Count - 1; i >= 0; i--)
                {
                    if (string.IsNullOrWhiteSpace(listOfTasks[i].Task))
                    {
                        listOfTasks.RemoveAt(i);
                    }
                }

                FileIOService.SaveData(listOfTasks, pathOfTasks);
            }
        }

        private async void RefreshListAsync()
        {
            if (successConnect == true)
            {
                listOfTasksGDrive.Clear();
                LoadDataFromGDrive();
                listOfTasks.Clear();
                listOfTasks = listOfTasksGDrive;
                await Task.Run(() => FileIOService.SaveData(listOfTasks, pathOfTasks));
            }
        }

        private void OrderByCategory()
        {
            string category = "Project";
            List<TaskBody> categories = new List<TaskBody>();
            categories = listOfTasks.Where(b => b.Category == category).ToList();
            

        }

        # region [Theme]
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ColumnsConfig()
        {
            dataGridView1.Columns[0].Width = 450;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 160;
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

        private void ButtonList_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
            ActivateButton(sender);
        }

        private void ButtonNote_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormNotes(), sender);
        }
        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSettings(), sender);
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

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonTest_Click(object sender, EventArgs e)
        {
            OrderByCategory();

            

            string searchTask = "Собрать вещи";
            int index = -1;

            for (int i = 0; i < listOfTasks.Count; i++)
            {
                if (listOfTasks[i].Task == searchTask)
                {
                    index = i;
                    break;
                }
            }

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RefreshListAsync();
            }
        }

        private void DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    if (!row.Selected)
                    {
                        dataGridView1.ClearSelection();

                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.Selected = true;
                        }

                        Point cursorPosition = dataGridView1.PointToClient(Control.MousePosition);
                        contextMenu.Show(dataGridView1, cursorPosition);
                    }
                }
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            listOfTasks.RemoveAt(index);
            this.googleHelper.DeleteRow(index);
        }
    }
}