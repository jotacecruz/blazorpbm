using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using BlazorPBM.Models;
using static System.Net.WebRequestMethods;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using Google.Apis.Json;
using System.ComponentModel;

namespace BlazorPBM.Services
{
    public class DatabaseService<T> where T : class
    {
        private const string SPREADSHEET_ID = "1-ekPWz0GwT3QNJmBdEs9xn2swOjOAK0xupPlxwoNMos";

        private readonly HttpClient _http;
        private readonly TokenService _tokenService;
        private readonly ErrorService _errorService;

        public DatabaseService(HttpClient http, TokenService tokenService, ErrorService errorService)
        {
            _http = http;
            _tokenService = tokenService;
            _errorService = errorService;
        }

        //private SheetsService GetSheetsService()
        //{
        //    using (var stream = new FileStream(_serviceAccountKeyPath, FileMode.Open, FileAccess.Read))
        //    {
        //        var credential = GoogleCredential.FromStream(stream).CreateScoped(SheetsService.Scope.SpreadsheetsReadonly); // Adjust scope as needed
        //        return new SheetsService(new BaseClientService.Initializer()
        //        {
        //            HttpClientInitializer = credential,
        //            ApplicationName = "YourAppName", // Replace with your app name
        //        });
        //    }
        //}

        public async Task<List<T>> LoadFromSheet(string sheet)
        {
            string? accessToken = _tokenService.GetAccessToken()?.Access_token;
            if (accessToken is null)
                _errorService.ReportError(new Exception("No access token set."));

            string url = $"https://sheets.googleapis.com/v4/spreadsheets/{SPREADSHEET_ID}/values/{sheet}";
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string response = await _http.GetStringAsync(url);
            return await ParseSheetToList(sheet, response);
        }

        private async Task<List<T>> ParseSheetToList(string sheet, string json)
        {
            List<T> result = new List<T>();
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(json);
            using var stream = new MemoryStream(utf8Bytes);
            using var doc = await JsonDocument.ParseAsync(stream);
            if (doc.RootElement.TryGetProperty("values", out var valuesElement) == false || valuesElement.ValueKind != JsonValueKind.Array)
                return result;

            List<JsonElement> values = valuesElement.EnumerateArray().ToList();
            if (values.Count < 2)
                return result;

            List<string?> headers = values[0].EnumerateArray().Select(h => h.GetString()).ToList();
            PropertyInfo[] properties = typeof(T).GetProperties();

            for (int i = 1; i < values.Count; i++)
            {
                T item = Activator.CreateInstance<T>();
                List<JsonElement> row = values[i].EnumerateArray().ToList();
                for (int j = 0; j < headers.Count && j < row.Count; j++)
                {
                    string? propName = headers[j];
                    PropertyInfo? prop = properties.FirstOrDefault(p => p.Name.Equals(propName, StringComparison.OrdinalIgnoreCase));
                    if (prop is not null)
                    {
                        try
                        {
                            string? value = row[j].GetString();
                            object? converted = Convert.ChangeType(value, prop.PropertyType);
                            prop.SetValue(item, converted);
                        }
                        catch
                        {
                            // optional: log or skip invalid entries
                        }
                    }
                }
                //PropertyInfo? databaseRow = item.GetType()?.GetProperty(nameof(Audit.DatabaseRow));
                //databaseRow?.SetValue(item, i + 1);
                //PropertyInfo? databaseRange = item.GetType()?.GetProperty(nameof(Audit.DatabaseRange));
                //databaseRange?.SetValue(item, $"{sheet}!A{i + 1}:{headers.Count}");

                result.Add(item);
            }
            return result;
        }

        public async Task<int> SaveToSheet(string sheet, T item, bool newRow = false)
        {
            string? accessToken = _tokenService.GetAccessToken()?.Access_token;
            if (accessToken is null)
                throw new InvalidOperationException("No access token set.");

            item.AddAuditInfo(_tokenService.UserInfo?.UserId ?? 0, newRow);

            GoogleSheetRow? row = ToValueRange(item);
            int? databaseRow = (int?)item.GetType()?.GetProperty(nameof(Audit.DatabaseRow))?.GetValue(item);
            row.range = $"{sheet}!A{databaseRow}:{typeof(T).GetProperties().Length.GetColumnLetter()}{databaseRow}";
            StringContent content = new StringContent(JsonSerializer.Serialize(row), Encoding.UTF8, MediaTypeHeaderValue.Parse("application/json"));

            string url = $"https://sheets.googleapis.com/v4/spreadsheets/{SPREADSHEET_ID}/values/{row.range}?valueInputOption=RAW";
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _http.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                // Process responseContent if needed
            }
            else
            {
                // Handle error
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Request failed: {error}");
            }

            return await Task.FromResult(1);
        }

        public static GoogleSheetRow ToValueRange<U>(U obj)
        {
            List<object> row = typeof(U).GetProperties()
                .Where(p => p.PropertyType.IsValueType || p.PropertyType == typeof(string))//include only value types and strings
                .Where(p => p.GetGetMethod()?.IsVirtual == false || p.GetGetMethod()?.IsFinal == true)//exclude virtual properties
                .Select(p => (object?)p.GetValue(obj) ?? string.Empty).ToList();
            return new GoogleSheetRow
            {
                majorDimension = "ROWS",
                range = string.Empty,
                values = new List<IList<object>> { row }
            };
        }

    }

    public class GoogleSheetRow
    {
        public string? range { get; set; }
        public string? majorDimension { get; set; }
        public IList<IList<object>>? values { get; set; }
    }
}
