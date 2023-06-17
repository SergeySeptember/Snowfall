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

        internal void Set(string cellName1, string cellName2, string value1, string value2)
        {
            var range = this.sheetName + "!" + cellName1 + ":" + cellName2;
            var values = new List<List<object>> { new List<object> { value1, value2 } };

            var request = this.sheetService.Spreadsheets.Values.Update(
                new ValueRange { Values = new List<IList<object>>(values) },
                spreadsheetId: this.sheetFileId,
                range: range
                );
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var response = request.Execute();
        }

        internal List<List<string>> Get(string cellName, string cellName2)
        {
            var range = this.sheetName + "!" + cellName + ":" + cellName2;

            var request = this.sheetService.Spreadsheets.Values.Get(
                spreadsheetId: this.sheetFileId,
                range: range
                );
            var response = request.Execute();

            List<List<string>> valuesList = new List<List<string>>();

            foreach (var row in response.Values)
            {
                List<string> rowValues = new List<string>();

                foreach (var cell in row)
                {
                    rowValues.Add(cell.ToString());
                }

                valuesList.Add(rowValues);
            }

            return valuesList;
        }
    }

}

