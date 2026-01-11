using System.Net.Http;

namespace Mark4.Client.Services
{
    public class FeedApiService : IFeedApiService
    {
        public HttpClient httpClient; // = new HttpClient();

        private string intervalNum = string.Empty;

        /*
        //builder.Services.AddHttpClient<IFeedApiService, FeedApiService>();
        //public HttpClient httpClient;
        //private readonly IServiceScopeFactory scopeFactory;
        public FeedApiService(HttpClient _httpClient, IServiceScopeFactory _scopeFactory)
        {
            httpClient = _httpClient;
            scopeFactory = _scopeFactory;
        }
        */

      
        public async Task<FeedApiTable> GetFeedTablesApi(string _instrumentName, string _intervalNum)
        {
            if (httpClient is null)
            {
                httpClient = new HttpClient();
            }
            string connectionString;
            intervalNum = _intervalNum;
            //www.alphavantage.co/documentation/
            if (_instrumentName.Contains("BSE"))
            {
                _intervalNum = "TIME_SERIES_DAILY";
                connectionString = "https://" + $@"www.alphavantage.co/query?function={_intervalNum}&symbol={_instrumentName}&outputsize=full&apikey=demo";
            }
            else
            {
                connectionString = "https://" + $@"www.alphavantage.co/query?function={_intervalNum}&symbol={_instrumentName}&apikey=demo";
            }
            HttpResponseMessage response = await httpClient.GetAsync(connectionString);
            string json = await response.Content.ReadAsStringAsync();
            FeedApiTable feedApiTableData = Newtonsoft.Json.JsonConvert.DeserializeObject<FeedApiTable>(json);
            return feedApiTableData;
        }


        public class FeedApiTable()
        {
            //stackoverflow.com/questions/76698149/how-to-parse-alphavantage-api-response-to-the-class-in-c-sharp
            //alphavantage.co/documentation/
            [Newtonsoft.Json.JsonProperty("Meta Data")]
            public MetaData MetaData { get; set; }
            [Newtonsoft.Json.JsonProperty("Monthly Time Series")]
            public Dictionary<string, TimeSeriesEntry> TimeSeriesMonthly { get; set; }
            [Newtonsoft.Json.JsonProperty("Time Series (Daily)")]
            public Dictionary<string, TimeSeriesEntry> TimeSeriesDaily { get; set; }
            [Newtonsoft.Json.JsonProperty("Weekly Time Series")]
            public Dictionary<string, TimeSeriesEntry> TimeSeriesWeekly { get; set; }
        }

        public class MetaData
        {
            [Newtonsoft.Json.JsonProperty("1. Information")]
            public string Information { get; set; }
            [Newtonsoft.Json.JsonProperty("2. Symbol")]
            public string Symbol { get; set; }
            [Newtonsoft.Json.JsonProperty("3. Last Refreshed")]
            public string LastRefreshed { get; set; }
            [Newtonsoft.Json.JsonProperty("4. Output Size")]
            public string OutputSize { get; set; }
            [Newtonsoft.Json.JsonProperty("5. Time Zone")]
            public string TimeZone { get; set; }
        }

        public class TimeSeriesEntry
        {
            [Newtonsoft.Json.JsonProperty("1. open")]
            public string Open { get; set; }
            [Newtonsoft.Json.JsonProperty("2. high")]
            public string High { get; set; }
            [Newtonsoft.Json.JsonProperty("3. low")]
            public string Low { get; set; }
            [Newtonsoft.Json.JsonProperty("4. close")]
            public string Close { get; set; }
            [Newtonsoft.Json.JsonProperty("5. adjusted close")]
            public string AdjustedClose { get; set; }
            [Newtonsoft.Json.JsonProperty("6. volume")]
            public string Volume { get; set; }
            [Newtonsoft.Json.JsonProperty("7. dividend amount")]
            public string DividendAmount { get; set; }
            [Newtonsoft.Json.JsonProperty("8. split coefficient")]
            public string SplitCoefficient { get; set; }
        }
    }
}




