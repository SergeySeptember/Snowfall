using Snowfall.Entity;
using Snowfall.Service;
using System.ComponentModel;

namespace Snowfall.Forms
{
    public partial class FormNotes : Form
    {
        public GoogleHelper secondGoogleHelper;
        private BindingList<NoteBody> _listOfNotes = new();
        private bool _successConnect;
        private bool _languageRus;
        private bool _expection = false;
        private string _color;
        public FormNotes(GoogleHelper googleHelper, BindingList<NoteBody> listOfNotes, bool successConnect, bool languageRus, string color)
        {
            secondGoogleHelper = googleHelper;
            _listOfNotes = listOfNotes;
            _successConnect = successConnect;
            _languageRus = languageRus;
            _color = color;

            InitializeComponent();
            LoadNotes();
            InitialLoadForm();
        }
        
        private void InitialLoadForm()
        {
            dataGridViewNotes.Columns[0].Width = 179;
            dataGridViewNotes.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(_color);
            if (_languageRus)
                dataGridViewNotes.Columns[0].HeaderText = "Заметки";
            else
                dataGridViewNotes.Columns[0].HeaderText = "Notes";
        }

        private void LoadNotes()
        {
            for (int i = 0; i < _listOfNotes.Count; i++)
            {
                dataGridViewNotes.DataSource = _listOfNotes;
            }
        }

        private void DataGridViewNotesCellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewNotes.CurrentCell.RowIndex;
            textBoxBody.Text = _listOfNotes[index].Description;
        }

        private void DataGridViewNotesCellEndEdit(object sender, DataGridViewCellEventArgs e) => SaveNoteChanges();

        private void TextBoxBodyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewNotes.Focus();
                SaveNoteChanges();
            }
        }

        public void SaveNoteChanges()
        {
            int index = dataGridViewNotes.CurrentCell.RowIndex;

            if (_listOfNotes.Count > index && !string.IsNullOrWhiteSpace(_listOfNotes[index].NoteName))
            {
                _listOfNotes[index].Description = textBoxBody.Text;

                if (_successConnect == true)
                {
                    int lineNumber = dataGridViewNotes.CurrentCell.RowIndex + 1;

                    secondGoogleHelper.SetNotes(cellName1: $"A{lineNumber}", cellName2: $"E{lineNumber}", _listOfNotes[index].NoteName, _listOfNotes[index].Description);
                }

                FileIOService.SaveNotesToJson(_listOfNotes);
            }
        }

        private void DataGridViewNotesCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewNotes.Rows[e.RowIndex];

                    if (!row.Selected)
                    {
                        dataGridViewNotes.ClearSelection();

                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.Selected = true;
                        }

                        Point cursorPosition = dataGridViewNotes.PointToClient(Control.MousePosition);
                        contextMenu.Show(dataGridViewNotes, cursorPosition);
                    }
                }
            }
        }

        private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
        {
            int index = dataGridViewNotes.CurrentCell.RowIndex;
            _listOfNotes.RemoveAt(index);
            secondGoogleHelper.DeleteRowOfNotes(index);
            FileIOService.SaveNotesToJson(_listOfNotes);
        }

        private async void DataGridViewNotesMouseEnter(object sender, EventArgs e)
        {
            while (!_expection && dataGridViewNotes.Location.X < textBoxBody.Location.X - 40)
            {
                _expection = true;
                await Task.Delay(1);
                dataGridViewNotes.Location = new Point(dataGridViewNotes.Location.X + 10, dataGridViewNotes.Location.Y);
                _expection = false;
            }
            _expection = false;
        }

        private async void DataGridViewNotesMouseLeave(object sender, EventArgs e)
        {
            while (!_expection && dataGridViewNotes.Location.X > -130)
            {
                _expection = true;
                await Task.Delay(1);
                dataGridViewNotes.Location = new Point(dataGridViewNotes.Location.X - 20, dataGridViewNotes.Location.Y);
                _expection = false;
            }
            _expection = false;
        }
    }
}
