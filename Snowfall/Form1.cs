namespace Snowfall
{
    public partial class Form1 : Form
    {
        private GoogleHelper helper;
        string[] token = File.ReadAllLines(@"C:\Users\September\Desktop\credentials.json");
        string todoSheet = "Example";

        public Form1()
        {
            InitializeComponent();

            StartConnect();
        }

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
            this.helper.Set(cellName: cell_1.Text, value: cell_2.Text);
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            var result = this.helper.Get(cellName: cell_3.Text);

            if (result != null)
            {
                cell_4.Text = result.ToString();
            }
            else
            {
                cell_4.Text = "Not data";
            }
        }
    }
}