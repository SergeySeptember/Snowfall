using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Snowfall
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
        private GoogleHelper _helper;
        string[] token = File.ReadAllLines(@"C:\Users\September\source\repos\Snowfall\Documents\token.json");
        string todoSheet = "Example";
        BindingList<TaskBody> listOfTusks = new BindingList<TaskBody>();
        string path = $"{Environment.CurrentDirectory}\\ListOfTasks.json";
        private FileIOService _fileIOService;
        bool successConnect;
        private BindingList<TaskBody> _taskBody;

        //New
        private Button currentButton;
        private int tempIndex;
        private Form activeForm;

        public BindingList<TaskBody> TaskBodyProperty
        {
            get => _taskBody;
            set
            {
                _taskBody = value;
                OnPropertyChanged();
            }
        }

        public Form1()
        {
            InitializeComponent();

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea; //Что это?
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataBindings.Add("DataSource", this, nameof(TaskBodyProperty));
            TaskBodyProperty = new BindingList<TaskBody>();

            StartConnect();
        }

        //New methods
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
            ActivateButton(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormNotes(), sender);
        }
        private void button3_Click(object sender, EventArgs e)
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



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private async void StartConnect()
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
                LoadDataFromGDrive();
            }
            else
            {
                LoadDataFromJson();
            }
            ColumnsConfig();
        }

        private void ColumnsConfig()
        {
            dataGridView1.Columns[0].Width = 457;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 160;
        }

        private void LoadDataFromGDrive()
        {
            int countOfRaw = NemberOfRawsOnGDrive();
            if (countOfRaw != 0)
            {
                for (int i = 1; i <= countOfRaw; i++)
                {
                    TaskBody result = this._helper.Get(cellName: $"A{i}", cellName2: $"D{i}");
                    listOfTusks.Add(result);
                }

                for (int i = 0; i < countOfRaw; i++)
                {
                    TaskBodyProperty.Add(listOfTusks[i]);
                }
            }
        }

        private int NemberOfRawsOnGDrive()
        {
            int countOfRaw = this._helper.GetCountOfRaws(cellName: "A", cellName2: "A");
            return countOfRaw;
        }

        private void LoadDataFromJson()
        {
            listOfTusks = FileIOService.LoadData(path);
            int count = listOfTusks.Count;

            for (int i = 0; i < count; i++)
            {
                TaskBodyProperty.Add(listOfTusks[i]);
            }
        }

        private void UpdateListTask()
        {
            int lineNumber = dataGridView1.CurrentCell.RowIndex + 1;
            int index = lineNumber - 1;
            var currentTaskBody = TaskBodyProperty[index];

            if (listOfTusks.Count < index)
            {
                listOfTusks[index].Task = currentTaskBody.Task;
                listOfTusks[index].Status = currentTaskBody.Status;
                listOfTusks[index].Category = currentTaskBody.Category;
                listOfTusks[index].Time = currentTaskBody.Time;
            }
            else
            {
                listOfTusks.Add(currentTaskBody);
            }

            FileIOService.SaveData(listOfTusks, path);
        }

        private void WriteDataToGoogle()
        {
            int lineNumber = dataGridView1.CurrentCell.RowIndex + 1;
            int index = lineNumber - 1;
            var taskBody = TaskBodyProperty[index];

            this._helper.Set(cellName1: $"A{lineNumber}", cellName2: $"D{lineNumber}", taskBody.Task, taskBody.Status.ToString(), taskBody.Category, taskBody.Time);
        }

        //Handler
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateListTask();

            if (successConnect == true)
                WriteDataToGoogle();
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}