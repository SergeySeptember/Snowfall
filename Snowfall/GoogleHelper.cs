using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Snowfall
{
    class GoogleHelper
    {
        private readonly string token;
        private readonly string sheetFileName;
        private UserCredential credentials;
        private DriveService driveService;
        private SheetsService sheetService;
        private string sheetFileId;
        private string sheetName;

        public string ApplicationName { get; private set; } = "Snowfall";

        public string[] Scopes { get; private set; } = new string[] {
            DriveService.Scope.Drive,
        SheetsService.Scope.Spreadsheets};

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

            if (!string.IsNullOrEmpty(this.sheetFileId))
            {
                var sheetRequest = this.sheetService.Spreadsheets.Get(this.sheetFileId);
                var sheetResponse = sheetRequest.Execute();

                this.sheetName = sheetResponse.Sheets[0].Properties.Title;

                return true;
            }

            return false;
        }

        internal void Set(string cellName1, string cellName2, string value1, string value2, string value3, string value4)
        {
            if (!string.IsNullOrEmpty(value1))
            {
                var range = this.sheetName + "!" + cellName1 + ":" + cellName2;
                var values = new List<List<object>> { new List<object> { value1, value2, value3, value4 } };

                var request = this.sheetService.Spreadsheets.Values.Update(
                    new ValueRange { Values = new List<IList<object>>(values) },
                    spreadsheetId: this.sheetFileId,
                    range: range
                    );
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                var response = request.Execute();
            }
            
        }

        public TaskBody Get(string cellName, string cellName2)
        {
            var range = this.sheetName + "!" + cellName + ":" + cellName2;

            var request = this.sheetService.Spreadsheets.Values.Get(
                spreadsheetId: this.sheetFileId,
                range: range
                );
            var response = request.Execute();

            TaskBody taskBody = new TaskBody();

            if (response.Values.Count > 0 && response.Values[0].Count > 0)
            {
                taskBody.Task = response.Values[0][0].ToString();

                if (response.Values[0].Count > 1 && response.Values[0][1] != null)
                {
                    taskBody.Status = Convert.ToBoolean(response.Values[0][1]);
                }
                else
                {
                    taskBody.Status = false;
                }

                if (response.Values[0].Count > 2 && response.Values[0][2] != null)
                {
                    taskBody.Category = response.Values[0][2].ToString();
                }
                else
                {
                    taskBody.Category = "";
                }

                if (response.Values[0].Count > 3 && response.Values[0][3] != null)
                {
                    taskBody.Time = response.Values[0][3].ToString();
                }
                else
                {
                    taskBody.Time = "";
                }
            }

            return taskBody;
        }

        public int GetCountOfRaws(string cellName, string cellName2)
        {
            var range = this.sheetName + "!" + cellName + ":" + cellName2;

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
    }
}