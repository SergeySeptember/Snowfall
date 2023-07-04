using Snowfall.Entity;
using System.ComponentModel;
using System.Windows.Forms;

namespace Snowfall.Forms
{
    public partial class FormNotes : Form
    {
        public GoogleHelper _secondGoogleHelper;
        BindingList<NoteBody> listOfNotes = new BindingList<NoteBody>();

        public FormNotes(GoogleHelper googleHelper, BindingList<NoteBody> listOfNotes)
        {
            this._secondGoogleHelper = googleHelper;
            this.listOfNotes = listOfNotes;
            InitializeComponent();
            LoadNotes();
            dataGridViewNotes.Columns[0].Width = 179;
        }

        public void LoadNotes()
        {
            for (int i = 0; i < listOfNotes.Count; i++)
            {
                dataGridViewNotes.DataSource = listOfNotes;
            }


        }

        private void ButtonAddClick(object sender, EventArgs e)
        {
            NoteBody newBody = new NoteBody() { NoteName = "Заглушка", Description = "Введи текст" };
            listOfNotes.Add(newBody);
        }

        private void dataGridViewNotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewNotes.CurrentCell.RowIndex;
            textBoxBody.Text = listOfNotes[index].Description;
        }
    }
}
