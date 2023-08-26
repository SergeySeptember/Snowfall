﻿using Snowfall.Entity;
using Snowfall.Service;
using System;
using System.ComponentModel;

namespace Snowfall.Forms
{
    public partial class FormNotes : Form
    {
        public GoogleHelper secondGoogleHelper;
        BindingList<NoteBody> listOfNotes = new BindingList<NoteBody>();
        private bool successConnect;
        private bool expection = false;
        public FormNotes(GoogleHelper googleHelper, BindingList<NoteBody> listOfNotes, bool successConnect, bool languageRus)
        {
            secondGoogleHelper = googleHelper;
            this.listOfNotes = listOfNotes;
            this.successConnect = successConnect;

            InitializeComponent();
            LoadNotes();

            dataGridViewNotes.Columns[0].Width = 179;
            dataGridViewNotes.Columns[0].Name = "Давай";
            //if (languageRus)
            //{
            //    dataGridViewNotes.Columns[0].Name = "Заметки";
            //}
            //else
            //{
            //    dataGridViewNotes.Columns[0].Name = "Notes";
            //}
        }

        public void LoadNotes()
        {
            for (int i = 0; i < listOfNotes.Count; i++)
            {
                dataGridViewNotes.DataSource = listOfNotes;
            }
        }

        private void dataGridViewNotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewNotes.CurrentCell.RowIndex;
            textBoxBody.Text = listOfNotes[index].Description;
        }

        private void dataGridViewNotes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SaveNoteChanges();
        }

        private void textBoxBody_KeyDown(object sender, KeyEventArgs e)
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

            if (listOfNotes.Count > index && !string.IsNullOrWhiteSpace(listOfNotes[index].NoteName))
            {
                listOfNotes[index].Description = textBoxBody.Text;

                if (successConnect == true)
                {
                    int lineNumber = dataGridViewNotes.CurrentCell.RowIndex + 1;

                    secondGoogleHelper.SetNotes(cellName1: $"A{lineNumber}", cellName2: $"E{lineNumber}", listOfNotes[index].NoteName, listOfNotes[index].Description);
                }

                FileIOService.SaveNotesToJson(listOfNotes);
            }
        }

        private void dataGridViewNotes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridViewNotes.CurrentCell.RowIndex;
            listOfNotes.RemoveAt(index);
            secondGoogleHelper.DeleteRowOfNotes(index);
            FileIOService.SaveNotesToJson(listOfNotes);
        }

        private async void dataGridViewNotes_MouseEnter(object sender, EventArgs e)
        {
            while (!expection && dataGridViewNotes.Location.X < textBoxBody.Location.X - 40)
            {
                expection = true;
                await Task.Delay(1);
                dataGridViewNotes.Location = new Point(dataGridViewNotes.Location.X + 10, dataGridViewNotes.Location.Y);
                expection = false;
            }
            expection = false;
        }

        private async void dataGridViewNotes_MouseLeave(object sender, EventArgs e)
        {
            while (!expection && dataGridViewNotes.Location.X > -130)
            {
                expection = true;
                await Task.Delay(1);
                dataGridViewNotes.Location = new Point(dataGridViewNotes.Location.X - 20, dataGridViewNotes.Location.Y);
                expection = false;
            }
            expection = false;
        }
    }
}
