using Snowfall.Service;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Snowfall
{
    public partial class MainForm : Form, INotifyPropertyChanged
    {
        private GoogleHelper _helper;
        private string[] token = File.ReadAllLines(@"C:\Users\September\source\repos\Snowfall\Documents\token.json");
        private string todoSheet = "Example";
        private string path = $"{Environment.CurrentDirectory}\\ListOfTasks.json";
        private bool successConnect;
        private BindingList<TaskBody> _taskBody;
        private Button currentButton;
        private Form activeForm;

        private BindingList<TaskBody> listOfTusksGDrive = new BindingList<TaskBody>();
        private BindingList<TaskBody> listOfTusksJSON = new BindingList<TaskBody>();
        public BindingList<TaskBody> listOfTusks
        {
            get => _taskBody;
            set
            {
                _taskBody = value;
                OnPropertyChanged();
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataBindings.Add("DataSource", this, nameof(listOfTusks));
            listOfTusks = new BindingList<TaskBody>();

            InitialLoad();
            ColumnsConfig();
        }

        private void InitialLoad()
        {
            this._helper = new GoogleHelper(token[0], todoSheet);

            try
            {
                successConnect = this._helper.Start().Result;
            }
            catch (Exception)
            {
                successConnect = false;
            }

            if (successConnect == true)
            {
                LoadAndSortData();
            }
            else
            {
                LoadDataFromJson();
            }
        }

        private void LoadDataFromGDrive()
        {
            int countOfRawOnGDrive = this._helper.GetCountOfRaws(cellName: "A", cellName2: "A");
            if (countOfRawOnGDrive != 0)
            {
                for (int i = 1; i <= countOfRawOnGDrive; i++)
                {
                    TaskBody result = this._helper.Get(cellName: $"A{i}", cellName2: $"E{i}");
                    listOfTusksGDrive.Add(result);
                }
            }
        }

        private void LoadAndSortData()
        {
            LoadDataFromGDrive();
            LoadDataFromJson();

            int countOfRawGDrive = listOfTusksGDrive.Count;
            int countOfRawJson = listOfTusksJSON.Count;

            int minCount = Math.Min(countOfRawJson, countOfRawGDrive);

            for (int i = 0; i < minCount; i++)
            {
                var time1 = DateTime.Parse(listOfTusksJSON[i].TimeUpdate);
                var time2 = DateTime.Parse(listOfTusksGDrive[i].TimeUpdate);

                if (time1 > time2)
                {
                    listOfTusks.Add(listOfTusksJSON[i]);
                }
                else
                {
                    listOfTusks.Add(listOfTusksGDrive[i]);
                }
            }

            for (int i = minCount; i < countOfRawJson; i++)
            {
                listOfTusks.Add(listOfTusksJSON[i]);
            }

            for (int i = minCount; i < countOfRawGDrive; i++)
            {
                listOfTusks.Add(listOfTusksGDrive[i]);
            }
        }

        private void LoadDataFromJson()
        {
            listOfTusksJSON = FileIOService.LoadData(path);
        }

        private void EditRawOfTask(int index, TaskBody currentTaskBody)
        {
            if (listOfTusks.Count < index)
            {
                listOfTusks.Add(currentTaskBody);
            }
            else
            {
                listOfTusks[index].Task = currentTaskBody.Task;
                listOfTusks[index].Status = currentTaskBody.Status;
                listOfTusks[index].Category = currentTaskBody.Category;
                listOfTusks[index].Time = currentTaskBody.Time;
                listOfTusks[index].TimeUpdate = DateTime.Now.ToString();
            }
        }

        private async void SaveCellEditAsync(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            if (!string.IsNullOrWhiteSpace(listOfTusks[index].Task))
            {
                var currentTaskBody = listOfTusks[index];

                EditRawOfTask(index, currentTaskBody);

                if (successConnect == true)
                {
                    int lineNumber = dataGridView1.CurrentCell.RowIndex + 1;
                    var taskBody = listOfTusks[index];

                    this._helper.Set(cellName1: $"A{lineNumber}", cellName2: $"E{lineNumber}", taskBody.Task, taskBody.Status.ToString(), taskBody.Category, taskBody.Time, taskBody.TimeUpdate = DateTime.Now.ToString());
                }

                await Task.Run(() => FileIOService.SaveData(listOfTusks, path));
            }
        }

        private async void RefreshListAsync()
        {
            if (successConnect == true)
            {
                listOfTusksGDrive.Clear();
                LoadDataFromGDrive();
                listOfTusks.Clear();
                listOfTusks = listOfTusksGDrive;
                await Task.Run(() => FileIOService.SaveData(listOfTusks, path));
            }
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

        //Events
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void buttonTest_Click(object sender, EventArgs e)
        {
            RefreshListAsync();
        }
    }
}