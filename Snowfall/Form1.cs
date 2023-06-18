using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Snowfall
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
        private GoogleHelper helper;
        string[] token = File.ReadAllLines(@"C:\Users\September\Desktop\credentials.json");
        string todoSheet = "Example";

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
            StartConnect();

            dataGridView1.DataBindings.Add("DataSource", this, nameof(TaskBodyProperty));
            TaskBodyProperty = new BindingList<TaskBody>();

            InitialLoadTask();
            ColumnsConfig();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        private async void StartConnect()
        {
            this.helper = new GoogleHelper(token[0], todoSheet);

            bool success = this.helper.Start().Result;
        }

        private void ColumnsConfig()
        {
            dataGridView1.Columns[0].Width = 300;
        }

        private int ExcelNemberOfRaws()
        {
            int countOfRaw = this.helper.GetCountOfRaws(cellName: "A", cellName2: "A");
            return countOfRaw;
        }

        private void InitialLoadTask()
        {
            int countOfRaw = ExcelNemberOfRaws();
            if (countOfRaw != 0)
            {
                for (int i = 1; i <= countOfRaw; i++)
                {
                    TaskBody result = this.helper.Get(cellName: $"A{i}", cellName2: $"D{i}");
                    TaskBodyProperty.Add(result);
                }

            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int lineNumber = dataGridView1.CurrentCell.RowIndex + 1;
            var taskBody = TaskBodyProperty[lineNumber - 1];

            this.helper.Set(cellName1: $"A{lineNumber}", cellName2: $"D{lineNumber}", taskBody.Task, taskBody.Status.ToString(), taskBody.Category, taskBody.Time);
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            //
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            //
        }

    }
}