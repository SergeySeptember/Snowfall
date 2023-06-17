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

            StartConnect();

            dataGridView1.DataBindings.Add("DataSource", this, nameof(TaskBodyProperty));
            TaskBodyProperty = new BindingList<TaskBody>();

            InitialLoadTask();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        private async void StartConnect()
        {
            this.helper = new GoogleHelper(token[0], todoSheet);

            bool success = this.helper.Start().Result;

            if (success == true)
            {
                buttonGet.Enabled = true;
                buttonSet.Enabled = true;
            }
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            int lineNumber = NumberOfRaws();
            var taskBody = TaskBodyProperty.Last();

            this.helper.Set(cellName1: $"A{lineNumber}", cellName2: $"B{lineNumber}", taskBody.Task, taskBody.Status.ToString());
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            var taskBody = TaskBodyProperty.Last();
            label1.Text = dataGridView1.CurrentCell.RowIndex.ToString();
            label2.Text = taskBody.Task;
        }

        private int NumberOfRaws()
        {
            return TaskBodyProperty.Count;
        }

        private void InitialLoadTask()
        {
            List<List<string>> allRaw = this.helper.Get(cellName: "A", cellName2: "A");
            int countOfRaw = allRaw.Count;

            for (int i = 1; i <= countOfRaw; i++)
            {
                List<List<string>> result = this.helper.Get(cellName: $"A{i}", cellName2: $"B{i}");
                bool checkBox = false;

                if (result[0][1] == "True")
                {
                    checkBox = true;
                }

                TaskBodyProperty.Add(new TaskBody { Task = result[0][0], Status = checkBox });

            }
        }


        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int lineNumber = dataGridView1.CurrentCell.RowIndex + 1;
            var taskBody = TaskBodyProperty[lineNumber - 1];

            this.helper.Set(cellName1: $"A{lineNumber}", cellName2: $"B{lineNumber}", taskBody.Task, taskBody.Status.ToString());
        }

    }
}