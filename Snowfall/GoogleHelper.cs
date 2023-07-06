using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using Snowfall.Entity;
using System.ComponentModel;
using System.Text;

namespace Snowfall
{
    public class GoogleHelper
    {
        private readonly string token;
        private readonly string sheetFileName;
        private UserCredential credentials;
        private DriveService driveService;
        private SheetsService sheetService;
        private string sheetFileId;
        private string sheetName;

        public string ApplicationName { get; private set; } = "Snowfall";

        public string[] Scopes { get; private set; } = new string[] { DriveService.Scope.Drive, SheetsService.Scope.Spreadsheets };

        public GoogleHelper(string token, string sheetFileName)
        {
            this.token = token;
            this.sheetFileName = sheetFileName;
        }

        internal async Task<bool> Start()
        {
            string credentialPath = Path.Combine(
                Environment.CurrentDirectory,
                ".credentials",
                ApplicationName);

            using (var strm = new MemoryStream(Encoding.UTF8.GetBytes(this.token)))
            {
                this.credentials = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    clientSecrets: GoogleClientSecrets.FromStream(strm).Secrets,
                    scopes: this.Scopes,
                    user: "user",
                    taskCancellationToken: CancellationToken.None,
                    new FileDataStore(credentialPath, true));
            }

            if (this.credentials == null)
            {
                return false;
            }

            this.driveService = new DriveService(new Google.Apis.Services.BaseClientService.Initializer
            {
                HttpClientInitializer = this.credentials,
                ApplicationName = ApplicationName,
            });

            this.sheetService = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer
            {
                HttpClientInitializer = this.credentials,
                ApplicationName = ApplicationName,
            });

            var request = this.driveService.Files.List();
            var response = request.Execute();

            foreach (var file in response.Files)
            {
                if (file.Name == this.sheetFileName)
                {
                    this.sheetFileId = file.Id;
                    break;
                }
            }

            if (this.sheetFileId == null)
            {
                var spreadsheet_body = new Spreadsheet();
                spreadsheet_body.Properties = new SpreadsheetProperties();
                spreadsheet_body.Properties.Title = "Snowfall";
                spreadsheet_body.Sheets = new List<Sheet>();

                var sheetTasks = new Sheet();
                sheetTasks.Properties = new SheetProperties();
                sheetTasks.Properties.Title = "Tasks";
                sheetTasks.Properties.SheetId = 1;
                sheetTasks.Properties.SheetType = "GRID";

                var sheetNotes = new Sheet();
                sheetNotes.Properties = new SheetProperties();
                sheetNotes.Properties.Title = "Notes";
                sheetNotes.Properties.SheetId = 2;
                sheetNotes.Properties.SheetType = "GRID";

                spreadsheet_body.Sheets.Add(sheetTasks);
                spreadsheet_body.Sheets.Add(sheetNotes);

                var create_request = sheetService.Spreadsheets.Create(spreadsheet_body);
                var spreadsheet = create_request.Execute();

                this.sheetFileId = spreadsheet.SpreadsheetId;
            }

            if (!string.IsNullOrEmpty(this.sheetFileId))
            {
                var sheetRequest = this.sheetService.Spreadsheets.Get(this.sheetFileId);
                var sheetResponse = sheetRequest.Execute();

                this.sheetName = sheetResponse.Sheets[0].Properties.Title;
            }
            return true;
        }

        public void SetTasks(string cellName1, string cellName2, string value1, string value2, string value3, string value4, string value5, string value6)
        {
                var range = this.sheetName + "!" + cellName1 + ":" + cellName2;
                var values = new List<List<object>> { new List<object> { value1, value2, value3, value4, value5, value6 } };

                var request = this.sheetService.Spreadsheets.Values.Update(
                    new ValueRange { Values = new List<IList<object>>(values) },
                    spreadsheetId: this.sheetFileId,
                    range: range
                    );
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                var response = request.Execute();
        }

        public BindingList<TaskBody> GetTasks(string cellName, string cellName2)
        {
            var range = this.sheetName + "!" + cellName + ":" + cellName2;

            var request = this.sheetService.Spreadsheets.Values.Get(
                spreadsheetId: this.sheetFileId,
                range: range
                );
            var response = request.Execute();

            BindingList<TaskBody> resultList = new BindingList<TaskBody>();

            for (int i = 0; i < response.Values.Count; i++)
            {
                TaskBody taskBody = new TaskBody();

                taskBody.Task = response.Values[i][0].ToString();
                taskBody.Status = Convert.ToBoolean(response.Values[i][1]);
                taskBody.Category = response.Values[i][2].ToString();
                taskBody.Time = response.Values[i][3].ToString();
                taskBody.TimeUpdate = response.Values[i][4].ToString();
                taskBody.IsDeleted = Convert.ToBoolean(response.Values[i][5]);

                resultList.Add(taskBody);
            }

            return resultList;
        }

        public int GetCountOfTasks()
        {
            var range = this.sheetName + "!A:A";

            var request = this.sheetService.Spreadsheets.Values.Get(
                spreadsheetId: this.sheetFileId,
                range: range
                );
            var response = request.Execute();

            if (response.Values is null)
            {
                return 0;
            }

            return response.Values.Count;
        }

        public void DeleteRowOfTask(int rowIndex)
        {
            var deleteRequest = new Request
            {
                DeleteDimension = new DeleteDimensionRequest
                {
                    Range = new DimensionRange
                    {
                        SheetId = 1,
                        Dimension = "ROWS",
                        StartIndex = rowIndex,
                        EndIndex = rowIndex + 1
                    }
                }
            };

            var batchUpdateRequest = new BatchUpdateSpreadsheetRequest
            {
                Requests = new List<Request> { deleteRequest }
            };

            var request = sheetService.Spreadsheets.BatchUpdate(batchUpdateRequest, this.sheetFileId);
            request.Execute();
        }
        public BindingList<NoteBody> GetNotes(string cellName, string cellName2)
        {
            var range = "Notes!" + cellName + ":" + cellName2;

            var request = this.sheetService.Spreadsheets.Values.Get(
                spreadsheetId: this.sheetFileId,
                range: range
                );
            var response = request.Execute();

            BindingList<NoteBody> resultList = new BindingList<NoteBody>();

            for (int i = 0; i < response.Values.Count; i++)
            {
                NoteBody noteBody = new NoteBody();

                noteBody.NoteName = response.Values[i][0].ToString();

                if (response.Values[i].Count > 1)
                    noteBody.Description = response.Values[i][1].ToString();
                else
                    noteBody.Description = "Введите текст";

                resultList.Add(noteBody);
            }

            return resultList;
        }

        public int GetCountOfNotes()
        {
            var range = "Notes!" + "A" + ":" + "A";

            var request = this.sheetService.Spreadsheets.Values.Get(
                spreadsheetId: this.sheetFileId,
                range: range
                );
            var response = request.Execute();

            if (response.Values is null)
            {
                return 0;
            }

            return response.Values.Count;
        }

        public void SetNotes(string cellName1, string cellName2, string value1, string value2)
        {
            var range = "Notes!" + cellName1 + ":" + cellName2;
            var values = new List<List<object>> { new List<object> { value1, value2 } };
            var request = this.sheetService.Spreadsheets.Values.Update(
            new ValueRange { Values = new List<IList<object>>(values) },
            spreadsheetId: this.sheetFileId,
            range: range
                );
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var response = request.Execute();
        }

        public void DeleteRowOfNotes(int rowIndex)
        {
            var deleteRequest = new Request
            {
                DeleteDimension = new DeleteDimensionRequest
                {
                    Range = new DimensionRange
                    {
                        SheetId = 2,
                        Dimension = "ROWS",
                        StartIndex = rowIndex,
                        EndIndex = rowIndex + 1
                    }
                }
            };

            var batchUpdateRequest = new BatchUpdateSpreadsheetRequest
            {
                Requests = new List<Request> { deleteRequest }
            };

            var request = sheetService.Spreadsheets.BatchUpdate(batchUpdateRequest, this.sheetFileId);
            request.Execute();
        }
    }
}