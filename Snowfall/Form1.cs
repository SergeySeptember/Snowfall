using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Snowfall
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
        private GoogleHelper _helper;
        string[] token = File.ReadAllLines(@"C:\Users\September\Desktop\credentials.json");
        string todoSheet = "Example";
        BindingList<TaskBody> listOfTusks = new BindingList<TaskBody>();
        string path = $"{Environment.CurrentDirectory}\\ListOfTasks.json";
        private FileIOService _fileIOService;
        bool successConnect;
        private BindingList<TaskBody> _taskBody;

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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataBindings.Add("DataSource", this, nameof(TaskBodyProperty));
            TaskBodyProperty = new BindingList<TaskBody>();

            StartConnect();
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
            dataGridView1.Columns[0].Width = 100;
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

    }
}