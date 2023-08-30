using Snowfall.Entity;
using Snowfall.Service;
using Snowfall.Service.ActionWithNotes;
using System;
using System.ComponentModel;
using System.Windows.Forms;

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
        private IONotes _iONotes;
        public FormNotes(GoogleHelper googleHelper, BindingList<NoteBody> listOfNotes, bool successConnect, bool languageRus, string color)
        {
            secondGoogleHelper = googleHelper;
            _listOfNotes = listOfNotes;
            _successConnect = successConnect;
            _languageRus = languageRus;
            _color = color;
            _iONotes = new(secondGoogleHelper);

            InitializeComponent();
            LoadNotes();
            InitialLoadForm();
        }
        
        private void InitialLoadForm()
        {
            dataGridViewNotes.Columns[0].Width = 179;
            dataGridViewNotes.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(_color);
            textBoxBody.Text = _listOfNotes[0].Description;

            if (_languageRus)
                dataGridViewNotes.Columns[0].HeaderText = "Заметки";
            else
                dataGridViewNotes.Columns[0].HeaderText = "Notes";
        }

        private void LoadNotes()
        {
            if (_listOfNotes.Count != 0)
            {
                dataGridViewNotes.DataSource = _listOfNotes;
            }
            else
            {
                _listOfNotes.Add(new NoteBody { NoteName = "Введите название", Description = "Введите текст" });
                dataGridViewNotes.DataSource = _listOfNotes;
            }
        }

        private void DataGridViewNotesCellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewNotes.CurrentCell.RowIndex;
            textBoxBody.Text = _listOfNotes[index].Description;
        }

        private void DataGridViewNotesCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _iONotes.SaveNoteChanges(dataGridViewNotes.CurrentCell.RowIndex, textBoxBody.Text, _successConnect, _listOfNotes);
            SendKeys.Send("{UP}");
        }
            

        private void TextBoxBodyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewNotes.Focus();
                _iONotes.SaveNoteChanges(dataGridViewNotes.CurrentCell.RowIndex, textBoxBody.Text, _successConnect, _listOfNotes);
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
            _iONotes.DeleteNote(index, textBoxBody.Text, _successConnect, _listOfNotes);
            _listOfNotes.RemoveAt(index);
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
